using System;
using System.Threading;

namespace PIDControllerLib
{
    public sealed class PIDController : IPIDController
    {
        #region Private Members

        private double processVariable = .0;
        private double processVariableLast = .0;

        private double integralTerm = .0;

        #endregion

        #region Properties

        public double Setpoint { get; set; } = .0;

        public double PGain { get; set; } = .0;

        public double IGain { get; set; } = .0;

        public double DGain { get; set; } = .0;

        public double OutputMax { get; set; } = .0;

        public double OutputMin { get; set; } = .0;

        public double ProcessVariable
        {
            get { return processVariable; }
            set
            {
                processVariableLast = processVariable;
                processVariable = value;
            }
        }

        #endregion

        #region Constructor

        public PIDController()
        {

        }

        public PIDController(double pGain, double iGain, double dGain)
            : this()
        {
            PGain = pGain;
            IGain = iGain;
            DGain = dGain;
        }

        public PIDController(double pGain, double iGain, double dGain, double outputMax, double outputMin)
            : this(pGain, iGain, dGain)
        {
            this.OutputMax = outputMax;
            this.OutputMin = outputMin;
        }

        #endregion

        #region Public Methods

        public double ControlVariable(TimeSpan timeSinceLastUpdate)
        {
            double error = Setpoint - ProcessVariable;

            // integral term calculation
            integralTerm += (IGain * error * (double)timeSinceLastUpdate.TotalMilliseconds);
            integralTerm = Clamp(integralTerm);

            // derivative term calculation
            double dInput = processVariable - processVariableLast;
            double derivativeTerm = DGain * (dInput / (double)timeSinceLastUpdate.TotalMilliseconds);

            // proportional term calcullation
            double proportionalTerm = PGain * error;

            double output = proportionalTerm + integralTerm + derivativeTerm;

            output = Clamp(output);

            return output;
        }

        #endregion

        #region Private Members

        private double Clamp(double variableToClamp)
        {
            if (variableToClamp <= OutputMin) { return OutputMin; }
            if (variableToClamp >= OutputMax) { return OutputMax; }

            return variableToClamp;
        }

        #endregion

        #region IDisposable pattern

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        #endregion
    }
}