using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraredLib
{
    public sealed class InfraredInterruptEvent
    {
        public bool IsHigh { get; private set; }

        public InfraredInterruptEvent()
            : base()
        {
            IsHigh = false;
        }

        public InfraredInterruptEvent(bool isHigh)
        {
            IsHigh = isHigh;
        }
    }

    public enum InfraredState
    {
        Active,
        Inactive
    }

    public interface IInfraredSensor
    {
        void Initialize();

        //void detectVoltage(object sender, object e);

        bool DetectVoltage();

        event EventHandler<InfraredInterruptEvent> InterruptHandler;
    }
}
