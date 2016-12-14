using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlLib
{
    public interface IMotorControl
    {
        void Start();

        void Stop();

        void Initialize();


    }
}
