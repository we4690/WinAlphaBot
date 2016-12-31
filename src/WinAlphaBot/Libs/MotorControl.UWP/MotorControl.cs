using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IoT.Lightning.Providers;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;
using Windows.Devices;

namespace MotorControlLib
{
    public sealed class MotorControl : IMotorControl
    {
        #region Private Members
        private GpioPin gpioPinIn1;
        private GpioPin gpioPinIn2;
        private PwmPin servoGpioPinEn;
        private GpioController gpioController;
        private PwmController pwmController;
        #endregion


        #region constructor

        public MotorControl(GpioController gpioControllerIn, PwmController pwmControllerIn)
        {
            gpioController = gpioControllerIn;
            pwmController = pwmControllerIn;
        }

        #endregion

        #region Public Methods

        public void Backward(double frequency, double dutyCycle)
        {
            if (pwmController == null || servoGpioPinEn == null || gpioPinIn1 == null || gpioPinIn2 == null)
                return;

            var max = pwmController.MaxFrequency;
            var min = pwmController.MinFrequency;
            frequency = Math.Min(frequency, max);
            frequency = Math.Max(frequency, min);

            var maxDuty = 1.0;
            var minDuty = 0.0;
            dutyCycle = Math.Min(dutyCycle, maxDuty);
            dutyCycle = Math.Max(dutyCycle, minDuty);

            pwmController.SetDesiredFrequency(frequency);
            servoGpioPinEn.SetActiveDutyCyclePercentage(dutyCycle);

            gpioPinIn1.Write(GpioPinValue.High);
            gpioPinIn2.Write(GpioPinValue.Low);

            servoGpioPinEn.Start();
        }

        public void Forward(double frequency, double dutyCycle)
        {
            if (pwmController == null || servoGpioPinEn == null || gpioPinIn1 == null || gpioPinIn2 == null)
                return;

            var max = pwmController.MaxFrequency;
            var min = pwmController.MinFrequency;
            frequency = Math.Min(frequency, max);
            frequency = Math.Max(frequency, min);

            var maxDuty = 1.0;
            var minDuty = 0.0;
            dutyCycle = Math.Min(dutyCycle, maxDuty);
            dutyCycle = Math.Max(dutyCycle, minDuty);

            pwmController.SetDesiredFrequency(frequency);
            servoGpioPinEn.SetActiveDutyCyclePercentage(dutyCycle);

            gpioPinIn1.Write(GpioPinValue.Low);
            gpioPinIn2.Write(GpioPinValue.High);

            servoGpioPinEn.Start();
        }

        public void Initialize(int PinIn1,int PinIn2,int PinPWM)
        {
            if (gpioController == null)
                return;
            if (pwmController == null)
                return;

            gpioPinIn1 = gpioController.OpenPin(PinIn1);
            gpioPinIn1.SetDriveMode(GpioPinDriveMode.Output);
            gpioPinIn1.Write(GpioPinValue.Low);

            gpioPinIn2 = gpioController.OpenPin(PinIn2);
            gpioPinIn2.SetDriveMode(GpioPinDriveMode.Output);
            gpioPinIn2.Write(GpioPinValue.Low);

            // Open pin 5 for pulse width modulation
            servoGpioPinEn = pwmController.OpenPin(PinPWM);
        }

        public void Start(double frequency, double dutyCycle)
        {
            if (pwmController == null || servoGpioPinEn == null || gpioPinIn1 == null || gpioPinIn2 == null)
                return;

            var max = pwmController.MaxFrequency;
            var min = pwmController.MinFrequency;
            frequency = Math.Min(frequency, max);
            frequency = Math.Max(frequency, min);

            var maxDuty = 1.0;
            var minDuty = 0.0;
            dutyCycle = Math.Min(dutyCycle, maxDuty);
            dutyCycle = Math.Max(dutyCycle, minDuty);

            pwmController.SetDesiredFrequency(frequency);
            servoGpioPinEn.SetActiveDutyCyclePercentage(dutyCycle);

            gpioPinIn1.Write(GpioPinValue.Low);
            gpioPinIn2.Write(GpioPinValue.High);

            servoGpioPinEn.Start();
        }

        public void Stop()
        {
            if (gpioPinIn1 == null || gpioPinIn2 == null)
                return;

            gpioPinIn1.Write(GpioPinValue.Low);
            gpioPinIn2.Write(GpioPinValue.Low);
        }

        public void TurnLeft()
        {
            throw new NotImplementedException();
        }

        public void TurnRight()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Disposable Pattern

        #region IDisposable pattern

        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        #endregion

        #endregion
    }
}
