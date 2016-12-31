using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBotControlServerLib
{
    public interface IAlphaBotControlServer : IDisposable
    {
        void Start();

        void Stop();

        string Address { get; }
    }
}
