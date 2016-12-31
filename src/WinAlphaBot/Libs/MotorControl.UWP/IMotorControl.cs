using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;

namespace MotorControlLib
{
    public interface IMotorControl : IDisposable
    {
        void Initialize(int PinIn1, int PinIn2, int PinPWM);

        void Start(double frequency, double dutyCycle);

        void Stop();

        void Forward(double frequency, double dutyCycle);

        void Backward(double frequency, double dutyCycle);

        void TurnLeft();

        void TurnRight();
    }
}
