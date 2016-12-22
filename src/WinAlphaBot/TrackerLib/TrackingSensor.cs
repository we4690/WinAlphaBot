using Microsoft.IoT.Lightning.Providers;
using System;
using Windows.Devices;
using Windows.Devices.Gpio;

namespace TrackingSensorLib
{
    public sealed class TrackingSensor : ITrackingSensor
    {
        #region Private Members

        private int pinNumber;

        private GpioPin pinInput;
        private GpioController gpio;

        #endregion

        #region Properties

        public event EventHandler<TrackingSensorEventArgs> InterruptHandler;

        public int PinNumber
        {
            get
            {
                return pinNumber;
            }
        }

        #endregion

        #region Constructor

        public TrackingSensor(int pin)
        {
            pinNumber = pin;
        }

        #endregion

        #region IInfraredSensor

        public void Initialize()
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            gpio = GpioController.GetDefault();

            pinInput = gpio.OpenPin(PinNumber);
            pinInput.SetDriveMode(GpioPinDriveMode.Input);

            pinInput.ValueChanged += OnPinValueChanged;
        }

        public void UnInitialize()
        {
            if (pinInput == null)
                return;

            pinInput.ValueChanged -= OnPinValueChanged;
        }

        public TrackingSensorStatus DetectStatus()
        {
            if (pinInput == null)
                return TrackingSensorStatus.Inactive;

            var value = pinInput.Read();

            return value == GpioPinValue.High ?
                    TrackingSensorStatus.Active
                    : TrackingSensorStatus.Inactive;
        }

        #endregion

        #region Private Functions

        private void OnPinValueChanged(object sender, GpioPinValueChangedEventArgs args)
        {
            var status = args.Edge == GpioPinEdge.RisingEdge ?
                TrackingSensorStatus.Active
                : TrackingSensorStatus.Inactive;

            //System.Diagnostics.Debug.WriteLine("valueLeft is " + status);

            OnInterruptOccurred(status);
        }

        private void OnInterruptOccurred(TrackingSensorStatus status)
        {
            //EventHandler<TrackerSensorEvent> interruptHandler = null;
            //Interlocked.CompareExchange(ref interruptHandler, InterruptHandler, null);

            if (InterruptHandler != null)
                InterruptHandler(this, new TrackingSensorEventArgs(status));
        }

        public void Dispose()
        {
            // TODO: Implement Dispose
        }

        #endregion
    }
}
