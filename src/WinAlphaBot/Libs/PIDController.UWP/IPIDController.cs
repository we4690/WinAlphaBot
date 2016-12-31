using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDControllerLib
{
    public interface IPIDController : IDisposable
    {
        double Setpoint { get; set; }

        double PGain { get; set; }

        double IGain { get; set; }

        double DGain { get; set; }

        double OutputMax { get; set; }

        double OutputMin { get; set; }

        double ProcessVariable { get; set; }

        double ControlVariable(TimeSpan timeSinceLastUpdate);
    }
}
