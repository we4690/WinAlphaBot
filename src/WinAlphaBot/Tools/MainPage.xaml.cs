using Microsoft.IoT.Lightning.Providers;
using System;
using System.Threading;
using TrackerLib;
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

        private ITrackerSensor trackerSensor1;
        private ITrackerSensor trackerSensor2;
        private ITrackerSensor trackerSensor3;
        private ITrackerSensor trackerSensor4;
        private ITrackerSensor trackerSensor5;

        private void btnTrackerInitialize_Click(object sender, RoutedEventArgs e)
        {
            trackerSensor1 = new TrackerSensor(4);
            trackerSensor1.Initialize();
            trackerSensor1.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor2 = new TrackerSensor(6);
            trackerSensor2.Initialize();
            trackerSensor2.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor3 = new TrackerSensor(22);
            trackerSensor3.Initialize();
            trackerSensor3.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor4 = new TrackerSensor(23);
            trackerSensor4.Initialize();
            trackerSensor4.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor5 = new TrackerSensor(27);
            trackerSensor5.Initialize();
            trackerSensor5.InterruptHandler += TrackerSensor_InterruptHandler;
        }

        private void btnTrackerUpdate_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("========================== btnTrackerUpdate_Click ================================ ");

            var status1 = trackerSensor1.DetectStatus();
            var number1 = trackerSensor1.PinNumber;
           // tbTrackerSensor1.Text = string.Format("Track sensor ={0};Track sensor ={1}", status1, number1);
            System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number1, status1);

            var status2 = trackerSensor2.DetectStatus();
            var number2 = trackerSensor2.PinNumber;
            // tbTrackerSensor2.Text = string.Format("Track sensor ={0};Track sensor ={1}", status2, number2);
            System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number2, status2);

            var status3 = trackerSensor3.DetectStatus();
            var number3 = trackerSensor3.PinNumber;
            // tbTrackerSensor2.Text = string.Format("Track sensor ={0};Track sensor ={1}", status3, number3);
            System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number3, status3);

            var status4 = trackerSensor4.DetectStatus();
            var number4 = trackerSensor4.PinNumber;
            // tbTrackerSensor2.Text = string.Format("Track sensor ={0};Track sensor ={1}", status4, number4);
            System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number4, status4);

            var status5 = trackerSensor5.DetectStatus();
            var number5 = trackerSensor5.PinNumber;
            // tbTrackerSensor2.Text = string.Format("Track sensor ={0};Track sensor ={1}", status5, number5);
            System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number5, status5);
            System.Diagnostics.Debug.WriteLine("========================== btnTrackerUpdate_Click end ================================ ");
        }

        private void btnTrackerUnInitialize_Click(object sender, RoutedEventArgs e)
        {
            trackerSensor1.InterruptHandler -= TrackerSensor_InterruptHandler;
            trackerSensor2.InterruptHandler -= TrackerSensor_InterruptHandler;
            trackerSensor3.InterruptHandler -= TrackerSensor_InterruptHandler;
            trackerSensor4.InterruptHandler -= TrackerSensor_InterruptHandler;
            trackerSensor5.InterruptHandler -= TrackerSensor_InterruptHandler;
        }

        //private DispatcherTimer timer;
        private void TrackerSensor_InterruptHandler(object sender, TrackerSensorEvent e)
        {

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(500);
            //timer.Tick += Timer_Tick;
            //timer.Start();
            System.Diagnostics.Debug.WriteLine("*************************** trackersensor_interrupthandler **************************** ");
            var tracker = sender as ITrackerSensor;

            switch (tracker.PinNumber)
            {
                case 4:
                    // todo: turn leftforward hard
                    //if(status1 == trackerSensor1.DetectStatus())
                    System.Diagnostics.Debug.WriteLine("turn left");
                    break;
                case 6:
                    // todo: turn leftforward hard
                    System.Diagnostics.Debug.WriteLine("turn leftforward");
                    break;
                case 22:
                    // todo: slowforward
                    System.Diagnostics.Debug.WriteLine("slowforward");
                    break;
                case 23:
                    // todo: turn rightforward hard
                    System.Diagnostics.Debug.WriteLine("turn rightforward");
                    break;
                case 27:
                    // todo: turn right hard
                    System.Diagnostics.Debug.WriteLine("turn right");
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("forward");
                    break;
            }

            System.Diagnostics.Debug.WriteLine("track sensor " + tracker.PinNumber + ", " + e.Status);
        }

        //private void Timer_Tick(object sender, object e)
        //{
        //    System.Diagnostics.Debug.WriteLine("*************************** TrackerSensor_InterruptHandler **************************** ");
        //    var tracker = sender as ITrackerSensor;

        //    switch (tracker.PinNumber)
        //    {
        //        case 4:
        //            // TODO: Turn Left hard
        //            System.Diagnostics.Debug.WriteLine("Turn Left");
        //            break;
        //        case 6:
        //            // TODO: Turn LeftForward hard
        //            System.Diagnostics.Debug.WriteLine("Turn LeftForward");
        //            break;
        //        case 22:
        //            // TODO: SlowForward
        //            System.Diagnostics.Debug.WriteLine("SlowForward");
        //            break;
        //        case 23:
        //            // TODO: Turn RightForward hard
        //            System.Diagnostics.Debug.WriteLine("Turn RightForward");
        //            break;
        //        case 27:
        //            // TODO: Turn Right hard
        //            System.Diagnostics.Debug.WriteLine("Turn Right");
        //            break;
        //        default:
        //            System.Diagnostics.Debug.WriteLine("Forward");
        //            break;
        //    }

        //    System.Diagnostics.Debug.WriteLine("Track sensor " + tracker.PinNumber + ", " + e.Status);
        //}
        #endregion


    }
}
