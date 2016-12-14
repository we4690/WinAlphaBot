using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlLib
{
    public interface IMotorControl
    {
        void Initialize();

        void Start();

        void Stop();

        void Forward();

        void Backward();

        void TurnLeft();

        void TurnRight();
    }
}
