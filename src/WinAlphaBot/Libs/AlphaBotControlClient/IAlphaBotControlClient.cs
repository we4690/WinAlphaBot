using AlphaBotControlLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBotControlClientLib
{
    public interface IAlphaBotControlClient : IDisposable
    {
        bool Connect(string address);

        bool SendCommand(AlphaBotControlCommand command);

        void SendCommandAsync(AlphaBotControlCommand command);
    }
}
