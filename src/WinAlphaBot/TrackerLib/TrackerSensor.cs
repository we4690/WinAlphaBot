using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace TrackerLib
{
    public sealed class TrackerSensor : ITrackerSensor
    {


        #region Private Members

        private int pinNumber;

        private GpioPin pinInput;
        private GpioController gpio;

        #endregion

        #region Properties

        public event EventHandler<TrackerSensorEvent> InterruptHandler;

        #endregion

        #region Constructor

        public TrackerSensor(int pin)
        {
            pinNumber = pin;
        }

        #endregion

        #region IInfraredSensor

        public void Initialize()
        {
            gpio = GpioController.GetDefault();

            pinInput = gpio.OpenPin(pinNumber);
            pinInput.SetDriveMode(GpioPinDriveMode.Input);

            pinInput.ValueChanged += OnPinValueChanged;
        }

        public void UnInitialize()
        {
            if (pinInput == null)
                return;

            pinInput.ValueChanged -= OnPinValueChanged;
        }

        public TrackerSensorStatus DetectStatus()
        {
            if (pinInput == null)
                return TrackerSensorStatus.Inactive;

            var value = pinInput.Read();

            return value == GpioPinValue.High ?
                    TrackerSensorStatus.Active
                    : TrackerSensorStatus.Inactive;
        }

        #endregion

        #region Private Functions

        private void OnPinValueChanged(object sender, GpioPinValueChangedEventArgs args)
        {
            var status = args.Edge == GpioPinEdge.RisingEdge ?
                TrackerSensorStatus.Active
                : TrackerSensorStatus.Inactive;

            System.Diagnostics.Debug.WriteLine("valueLeft is " + status);

            OnInterruptOccurred(status);
        }

        private void OnInterruptOccurred(TrackerSensorStatus status)
        {
            EventHandler<TrackerSensorEvent> interruptHandler = null;
            interruptHandler = Interlocked.CompareExchange(ref interruptHandler, InterruptHandler, null);

            if (interruptHandler != null)
                interruptHandler(this, new TrackerSensorEvent(status));
        }

        #endregion
    }
}
