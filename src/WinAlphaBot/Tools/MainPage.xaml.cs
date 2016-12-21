using Microsoft.IoT.Lightning.Providers;
using System;
using Windows.Devices;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tools
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region GPIO

        private GpioController gpioController;
        private GpioPin gpioPin;

        private async void btnLedInitialize_Click(object sender, RoutedEventArgs e)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            gpioController = await GpioController.GetDefaultAsync();

            gpioPin = gpioController.OpenPin(5);

            gpioPin.SetDriveMode(GpioPinDriveMode.Output);
        }

        private async void btnLedOn_Click(object sender, RoutedEventArgs e)
        {
            gpioPin.Write(GpioPinValue.High);
        }

        private void btnLedOff_Click(object sender, RoutedEventArgs e)
        {
            gpioPin.Write(GpioPinValue.Low);
        }

        #endregion

        #region PWM

        private async void btnPwmInitialize_Click(object sender, RoutedEventArgs e)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            var pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
            if (pwmControllers != null)
            {
                // use the on-device controller
                var pwmController = pwmControllers[1];

                // Set the frequency, defaulted to 50Hz
                pwmController.SetDesiredFrequency(pwmController.MinFrequency);

                // Open pin 5 for pulse width modulation
                var servoGpioPin = pwmController.OpenPin(18);

                // Set the Duty Cycle - 0.05 will set the servo to its 0 degree position
                servoGpioPin.SetActiveDutyCyclePercentage(.9);

                // Start PWN from pin 5, and give the servo a second to move to position
                servoGpioPin.Start();
                //Task.Delay(1000).Wait();
                //servoGpioPin.Stop();

                //// Set the Duty Cycle - 0.1 will set the servo to its 180 degree position
                //servoGpioPin.SetActiveDutyCyclePercentage(0.1);

                //// Start PWN from pin 5, and give the servo a second to move to position
                //servoGpioPin.Start();
                //Task.Delay(1000).Wait();
                //servoGpioPin.Stop();
            }
            //var infraredSensor = new InfraredSensor(4);
            //infraredSensor.Initialize();

            //infraredSensor.InterruptHandler += InfraredSensor_InterruptHandler;
        }

        //private void InfraredSensor_InterruptHandler(object sender, InfraredInterruptEvent e)
        //{
        //    //    InfraredState status = e.Status;
        //    //    switch(status)
        //    //    {
        //    //        case InfraredState.Active:
        //    //            var motorControl = new MotorControl();
        //    //            motorControl.TurnLeft();
        //    //            break;
        //    //        case InfraredState.Inactive:
        //    //            break;
        //    //        default:
        //    //            break;
        //    //    }
        //}

        private void btnPwmStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPwmStop_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Tracker Sensor

        #endregion
    }
}
