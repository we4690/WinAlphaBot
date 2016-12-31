using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDControllerLib
{
    [CompilerGenerated]
    public class StubIPIDController : IPIDController
    {
        private readonly StubContainer<StubIPIDController> _stubs = new StubContainer<StubIPIDController>();

        double global::PIDControllerLib.IPIDController.Setpoint
        {
            get
            {
                return _stubs.GetMethodStub<Setpoint_Get_Delegate>("get_Setpoint").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<Setpoint_Set_Delegate>("put_Setpoint").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.PGain
        {
            get
            {
                return _stubs.GetMethodStub<PGain_Get_Delegate>("get_PGain").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<PGain_Set_Delegate>("put_PGain").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.IGain
        {
            get
            {
                return _stubs.GetMethodStub<IGain_Get_Delegate>("get_IGain").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<IGain_Set_Delegate>("put_IGain").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.DGain
        {
            get
            {
                return _stubs.GetMethodStub<DGain_Get_Delegate>("get_DGain").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<DGain_Set_Delegate>("put_DGain").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.OutputMax
        {
            get
            {
                return _stubs.GetMethodStub<OutputMax_Get_Delegate>("get_OutputMax").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<OutputMax_Set_Delegate>("put_OutputMax").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.OutputMin
        {
            get
            {
                return _stubs.GetMethodStub<OutputMin_Get_Delegate>("get_OutputMin").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<OutputMin_Set_Delegate>("put_OutputMin").Invoke(value);
            }
        }

        double global::PIDControllerLib.IPIDController.ProcessVariable
        {
            get
            {
                return _stubs.GetMethodStub<ProcessVariable_Get_Delegate>("get_ProcessVariable").Invoke();
            }

            set
            {
                _stubs.GetMethodStub<ProcessVariable_Set_Delegate>("put_ProcessVariable").Invoke(value);
            }
        }

        public delegate double Setpoint_Get_Delegate();

        public StubIPIDController Setpoint_Get(Setpoint_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void Setpoint_Set_Delegate(double value);

        public StubIPIDController Setpoint_Set(Setpoint_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double PGain_Get_Delegate();

        public StubIPIDController PGain_Get(PGain_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void PGain_Set_Delegate(double value);

        public StubIPIDController PGain_Set(PGain_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double IGain_Get_Delegate();

        public StubIPIDController IGain_Get(IGain_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void IGain_Set_Delegate(double value);

        public StubIPIDController IGain_Set(IGain_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double DGain_Get_Delegate();

        public StubIPIDController DGain_Get(DGain_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void DGain_Set_Delegate(double value);

        public StubIPIDController DGain_Set(DGain_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double OutputMax_Get_Delegate();

        public StubIPIDController OutputMax_Get(OutputMax_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void OutputMax_Set_Delegate(double value);

        public StubIPIDController OutputMax_Set(OutputMax_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double OutputMin_Get_Delegate();

        public StubIPIDController OutputMin_Get(OutputMin_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void OutputMin_Set_Delegate(double value);

        public StubIPIDController OutputMin_Set(OutputMin_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate double ProcessVariable_Get_Delegate();

        public StubIPIDController ProcessVariable_Get(ProcessVariable_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate void ProcessVariable_Set_Delegate(double value);

        public StubIPIDController ProcessVariable_Set(ProcessVariable_Set_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        double global::PIDControllerLib.IPIDController.ControlVariable(global::System.TimeSpan timeSinceLastUpdate)
        {
            return _stubs.GetMethodStub<ControlVariable_TimeSpan_Delegate>("ControlVariable").Invoke(timeSinceLastUpdate);
        }

        public delegate double ControlVariable_TimeSpan_Delegate(global::System.TimeSpan timeSinceLastUpdate);

        public StubIPIDController ControlVariable(ControlVariable_TimeSpan_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIPIDController Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}