using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;

namespace MotorControlLib
{
    [CompilerGenerated]
    public class StubIMotorControl : IMotorControl
    {
        private readonly StubContainer<StubIMotorControl> _stubs = new StubContainer<StubIMotorControl>();

        void global::MotorControlLib.IMotorControl.Initialize(int PinIn1, int PinIn2, int PinPWM)
        {
            _stubs.GetMethodStub<Initialize_Int32_Int32_Int32_Delegate>("Initialize").Invoke(PinIn1, PinIn2, PinPWM);
        }

        public delegate void Initialize_Int32_Int32_Int32_Delegate(int PinIn1, int PinIn2, int PinPWM);

        public StubIMotorControl Initialize(Initialize_Int32_Int32_Int32_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.Start(double frequency, double dutyCycle)
        {
            _stubs.GetMethodStub<Start_Double_Double_Delegate>("Start").Invoke(frequency, dutyCycle);
        }

        public delegate void Start_Double_Double_Delegate(double frequency, double dutyCycle);

        public StubIMotorControl Start(Start_Double_Double_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.Stop()
        {
            _stubs.GetMethodStub<Stop_Delegate>("Stop").Invoke();
        }

        public delegate void Stop_Delegate();

        public StubIMotorControl Stop(Stop_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.Forward(double frequency, double dutyCycle)
        {
            _stubs.GetMethodStub<Forward_Double_Double_Delegate>("Forward").Invoke(frequency, dutyCycle);
        }

        public delegate void Forward_Double_Double_Delegate(double frequency, double dutyCycle);

        public StubIMotorControl Forward(Forward_Double_Double_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.Backward(double frequency, double dutyCycle)
        {
            _stubs.GetMethodStub<Backward_Double_Double_Delegate>("Backward").Invoke(frequency, dutyCycle);
        }

        public delegate void Backward_Double_Double_Delegate(double frequency, double dutyCycle);

        public StubIMotorControl Backward(Backward_Double_Double_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.TurnLeft()
        {
            _stubs.GetMethodStub<TurnLeft_Delegate>("TurnLeft").Invoke();
        }

        public delegate void TurnLeft_Delegate();

        public StubIMotorControl TurnLeft(TurnLeft_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::MotorControlLib.IMotorControl.TurnRight()
        {
            _stubs.GetMethodStub<TurnRight_Delegate>("TurnRight").Invoke();
        }

        public delegate void TurnRight_Delegate();

        public StubIMotorControl TurnRight(TurnRight_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIMotorControl Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}