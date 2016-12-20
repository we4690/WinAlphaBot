using System;
using System.Threading;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;

namespace InfraredLib
{
    public sealed class InfraredSensor : IInfraredSensor
    {
        #region Private Members

        private int pinNumber;

        private const int PinLeft = 4;
        private const int PinRight = 5;

        private GpioPin pinInputLeft;
        private GpioPin pinInputRight;
        private DispatcherTimer timer;

        #endregion

        #region Properties

        public event EventHandler<InfraredInterruptEvent> InterruptHandler;

        #endregion

        #region Constructor

        public InfraredSensor(int pin)
        {
            pinNumber = pin;
        }

        #endregion

        #region IInfraredSensor

        public void Initialize()
        {
            var gpio = GpioController.GetDefault();

            pinInputLeft = gpio.OpenPin(pinNumber);       //pin 7 
            pinInputRight = gpio.OpenPin(PinRight);     //pi 29
            pinInputLeft.SetDriveMode(GpioPinDriveMode.Input);
            pinInputRight.SetDriveMode(GpioPinDriveMode.Input);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += detectVoltage1;
            timer.Start();

            // TODO: consider using the below code snippet
            pinInputLeft.ValueChanged += (o, e) =>
            {
                bool isHigh = e.Edge == GpioPinEdge.RisingEdge;

                System.Diagnostics.Debug.WriteLine("valueLeft is " + isHigh);

                OnInterruptOccurred(isHigh);
            };
        }

        public bool DetectVoltage()
        {
            return false;
            //TODO: read GPIO voltage
        }

        public void detectVoltage1(object sender, object e)
        {
            GpioPinValue valueLeft = pinInputLeft.Read();
            GpioPinValue valueRight = pinInputRight.Read();
            if (valueLeft == GpioPinValue.High)
            {
                System.Diagnostics.Debug.WriteLine("valueLeft is High");
            }
            else if (valueLeft == GpioPinValue.Low)
            {
                System.Diagnostics.Debug.WriteLine("valueLeft is Low");
            }
            if (valueRight == GpioPinValue.High)
            {
                System.Diagnostics.Debug.WriteLine("valueRight is High");
            }
            else if (valueRight == GpioPinValue.Low)
            {
                System.Diagnostics.Debug.WriteLine("valueRight is Low");
            }
        }

        #endregion

        #region Private Functions

        private void OnInterruptOccurred(bool isHigh)
        {
            EventHandler<InfraredInterruptEvent> interruptHandler = null;
            interruptHandler = Interlocked.CompareExchange(ref interruptHandler, InterruptHandler, null);

            if (interruptHandler != null)
                interruptHandler(this, new InfraredInterruptEvent(isHigh));
        }

        #endregion
    }
}
