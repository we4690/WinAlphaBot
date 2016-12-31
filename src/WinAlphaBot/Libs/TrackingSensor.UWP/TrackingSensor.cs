using Microsoft.IoT.Lightning.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private GpioPinValue previousValue;
        private GpioPinValue pinValue;

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
            pinValue = pinInput.Read();

            if (previousValue == pinValue)
                return;

            previousValue = pinValue;

            var status = pinValue == GpioPinValue.High ?
                    TrackingSensorStatus.Active
                    : TrackingSensorStatus.Inactive;

            OnInterruptOccurred(status);
        }

        private void OnInterruptOccurred(TrackingSensorStatus status)
        {
            InterruptHandler?.Invoke(this, new TrackingSensorEventArgs(status));
        }

        #endregion

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
    }
}
