using System;
using System.Runtime.CompilerServices;
using Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBotControlServerLib
{
    [CompilerGenerated]
    public class StubIAlphaBotControlServer : IAlphaBotControlServer
    {
        private readonly StubContainer<StubIAlphaBotControlServer> _stubs = new StubContainer<StubIAlphaBotControlServer>();

        string global::AlphaBotControlServerLib.IAlphaBotControlServer.Address
        {
            get
            {
                return _stubs.GetMethodStub<Address_Get_Delegate>("get_Address").Invoke();
            }
        }

        void global::AlphaBotControlServerLib.IAlphaBotControlServer.Start()
        {
            _stubs.GetMethodStub<Start_Delegate>("Start").Invoke();
        }

        public delegate void Start_Delegate();

        public StubIAlphaBotControlServer Start(Start_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::AlphaBotControlServerLib.IAlphaBotControlServer.Stop()
        {
            _stubs.GetMethodStub<Stop_Delegate>("Stop").Invoke();
        }

        public delegate void Stop_Delegate();

        public StubIAlphaBotControlServer Stop(Stop_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public delegate string Address_Get_Delegate();

        public StubIAlphaBotControlServer Address_Get(Address_Get_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        void global::System.IDisposable.Dispose()
        {
            _stubs.GetMethodStub<IDisposable_Dispose_Delegate>("Dispose").Invoke();
        }

        public delegate void IDisposable_Dispose_Delegate();

        public StubIAlphaBotControlServer Dispose(IDisposable_Dispose_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }
    }
}