using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSensorLib
{
    [CompilerGenerated]
    public class StubITrackingSensor : ITrackingSensor
    {
        private readonly StubContainer<StubITrackingSensor> _stubs = new StubContainer<StubITrackingSensor>();

        int global::TrackingSensorLib.ITrackingSensor.PinNumber
        {
            get
            {
                return _stubs.GetMethodStub<PinNumber_Get_Delegate>("get_PinNumber").Invoke();
            }
        }

        void global::TrackingSensorLib.ITrackingSensor.Initialize()
        {
            _stubs.GetMethodStub<Initialize_Delegate>("Initialize").Invoke();
        }

        public delegate void Initialize_Delegate();

        public StubITrackingSensor Initialize(Initialize_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::TrackingSensorLib.ITrackingSensor.UnInitialize()
        {
            _stubs.GetMethodStub<UnInitialize_Delegate>("UnInitialize").Invoke();
        }

        public delegate void UnInitialize_Delegate();

        public StubITrackingSensor UnInitialize(UnInitialize_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate int PinNumber_Get_Delegate();

        public StubITrackingSensor PinNumber_Get(PinNumber_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        global::TrackingSensorLib.TrackingSensorStatus global::TrackingSensorLib.ITrackingSensor.DetectStatus()
        {
            return _stubs.GetMethodStub<DetectStatus_Delegate>("DetectStatus").Invoke();
        }

        public delegate global::TrackingSensorLib.TrackingSensorStatus DetectStatus_Delegate();

        public StubITrackingSensor DetectStatus(DetectStatus_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public event global::System.EventHandler<global::TrackingSensorLib.TrackingSensorEventArgs> InterruptHandler;

        protected void On_InterruptHandler(object sender, TrackingSensorEventArgs args)
        {
            global::System.EventHandler<global::TrackingSensorLib.TrackingSensorEventArgs> handler = InterruptHandler;
            if (handler != null) { handler(sender, args); }
        }

        public void InterruptHandler_Raise(object sender, TrackingSensorEventArgs args)
        {
            On_InterruptHandler(sender, args);
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubITrackingSensor Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}