using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraredLib
{
    //public class InfraredInterruptEvent : EventArgs
    //{
    //    public bool IsHigh { get; private set; }

    //    public InfraredInterruptEvent()
    //        : base()
    //    {
    //        IsHigh = false;
    //    }
    //}
    
    public interface IInfraredSensor
    {

        void Initialize();
        void detectVoltage(object sender, object e);
        //EventHandler InterruptHandler { get; set; }
    }
}
