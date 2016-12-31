using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraredSensorLib
{
    [CompilerGenerated]
    public class StubIInfraredSensor : IInfraredSensor
    {
        private readonly StubContainer<StubIInfraredSensor> _stubs = new StubContainer<StubIInfraredSensor>();

        void global::InfraredSensorLib.IInfraredSensor.Initialize()
        {
            _stubs.GetMethodStub<Initialize_Delegate>("Initialize").Invoke();
        }

        public delegate void Initialize_Delegate();

        public StubIInfraredSensor Initialize(Initialize_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        bool global::InfraredSensorLib.IInfraredSensor.DetectVoltage()
        {
            return _stubs.GetMethodStub<DetectVoltage_Delegate>("DetectVoltage").Invoke();
        }

        public delegate bool DetectVoltage_Delegate();

        public StubIInfraredSensor DetectVoltage(DetectVoltage_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.EventHandler<global::InfraredSensorLib.InfraredInterruptEvent> InterruptHandler;

        protected void On_InterruptHandler(object sender, InfraredInterruptEvent args)
        {
            global::System.EventHandler<global::InfraredSensorLib.InfraredInterruptEvent> handler = InterruptHandler;
            if (handler != null) { handler(sender, args); }
        }

        public void InterruptHandler_Raise(object sender, InfraredInterruptEvent args)
        {
            On_InterruptHandler(sender, args);
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIInfraredSensor Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}