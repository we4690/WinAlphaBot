using System;
using System.Threading;

namespace PIDLib
{
    public sealed class PID
    {
        #region Private Members

        private bool closedLoop = false;

        private double clockRate = 1.0; // 1Hz
    
        private double p = .0;
        private double i = .0;
        private double d = .0;

        private double setpoint = .0;
        private double output = .0;

        #endregion

        #region Properties

        public double Setpoint
        {
            get
            {
                return setpoint;
            }

            set
            {
                setpoint = value;
            }
        }

        public double Output
        {
            get
            {
                if (closedLoop)
                    return output;
                else
                    return setpoint;
            }
        }

        public double ClockRate
        {
            get
            {
                return clockRate;
            }

            set
            {
                clockRate = value;
            }
        }

        public double P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public double I
        {
            get
            {
                return i;
            }

            set
            {
                i = value;
            }
        }

        public double D
        {
            get
            {
                return d;
            }

            set
            {
                d = value;
            }
        }

        public event EventHandler<double> OutputChanged;

        #endregion

        #region Constructor

        public PID()
        {

        }

        public PID(double p, double i, double d)
            : base()
        {
            P = p;
            I = i;
            D = d;

            closedLoop = false;
        }

        #endregion

        #region Public Methods

        public void ActivateOpenLoop()
        {
            closedLoop = false;
        }

        public void ActivateClosedLoop()
        {
            closedLoop = true;
        }

        #endregion

        #region Private Members

        private void OnOutputChanged()
        {
            EventHandler<double> outputChanged = null;
            outputChanged = Interlocked.CompareExchange(ref outputChanged, OutputChanged, null);

            if (outputChanged != null)
                outputChanged(this, output);
        }


        #endregion
    }
}
