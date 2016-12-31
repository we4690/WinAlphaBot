using Microsoft.IoT.Lightning.Providers;
using MotorControlLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackingSensorLib;
using Windows.Devices;
using Windows.Devices.Gpio;
using Windows.Devices.Pwm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinAlphaBotTest
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

        #region LeftMotorControl.UWPTest
        private IMotorControl LeftMotor;
        private const int LEFTINA = 20;
        private const int LEFTINB = 21;
        private const int LEFTPWM = 13;
        private IReadOnlyList<PwmController> pwmControllers;
        private async void btnPwmInitialize_Click1(object sender, RoutedEventArgs e)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            gpioController = await GpioController.GetDefaultAsync();
            if (gpioController == null)
                return;

            pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
            if (pwmControllers == null)
                return;

            LeftMotor = new MotorControl(gpioController, pwmControllers[1]);
            LeftMotor.Initialize(LEFTINA, LEFTINB, LEFTPWM);
        }

        private void btnPwmStart_Click1(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency1 = double.Parse(tbPWMFrequency1.Text);
            var desiredDutyCycle1 = double.Parse(tbPWMDutyCycle1.Text);
            LeftMotor.Start(desiredFrequency1, desiredDutyCycle1);
        }

        private void btnPwmStop_Click1(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Stop();
        }
        private void btnPwmForward_Click1(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency1 = double.Parse(tbPWMFrequency1.Text);
            var desiredDutyCycle1 = double.Parse(tbPWMDutyCycle1.Text);
            LeftMotor.Forward(desiredFrequency1, desiredDutyCycle1);
        }
        private void btnPwmBackward_Click1(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency1 = double.Parse(tbPWMFrequency1.Text);
            var desiredDutyCycle1 = double.Parse(tbPWMDutyCycle1.Text);
            LeftMotor.Backward(desiredFrequency1, desiredDutyCycle1);
        }
        #endregion

        #region RightMotorControl.UWPTest
        private IMotorControl RightMotor;
        private const int RIGHTINA = 6;
        private const int RIGHTINB = 26;
        private const int RIGHTPWM = 12;

        private async void btnPwmInitialize_Click2(object sender, RoutedEventArgs e)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            gpioController = await GpioController.GetDefaultAsync();
            if (gpioController == null)
                return;

            pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
            if (pwmControllers == null)
                return;

            RightMotor = new MotorControl(gpioController, pwmControllers[1]);
            RightMotor.Initialize(RIGHTINA, RIGHTINB, RIGHTPWM);
        }

        private void btnPwmStart_Click2(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency2 = double.Parse(tbPWMFrequency2.Text);
            var desiredDutyCycle2 = double.Parse(tbPWMDutyCycle2.Text);
            RightMotor.Start(desiredFrequency2, desiredDutyCycle2);
        }

        private void btnPwmStop_Click2(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            RightMotor.Stop();
        }
        private void btnPwmForward_Click2(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency2 = double.Parse(tbPWMFrequency2.Text);
            var desiredDutyCycle2 = double.Parse(tbPWMDutyCycle2.Text);
            RightMotor.Forward(desiredFrequency2, desiredDutyCycle2);
        }
        private void btnPwmBackward_Click2(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            var desiredFrequency2 = double.Parse(tbPWMFrequency2.Text);
            var desiredDutyCycle2 = double.Parse(tbPWMDutyCycle2.Text);
            RightMotor.Backward(desiredFrequency2, desiredDutyCycle2);
        }

        #endregion

        #region LeftFront
        private void btnLeftFront_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Start(1000, 0.3);
            RightMotor.Start(1000, 0.4);
        }
        #endregion
        #region TurnLeft
        private void btnTurnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Stop();
            RightMotor.Start(1000, 0.4);
        }
        private void turn_left()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Stop();
            RightMotor.Start(1000, 0.4);
        }
        #endregion
        #region RightFront
        private void btnRightFront_Click(object sender, RoutedEventArgs e)
        {
            LeftMotor.Start(1000, 0.4);
            RightMotor.Start(1000, 0.3);
        }
        #endregion
        #region TurnRight
        private void btnTurnRight_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Start(1000, 0.4);
            RightMotor.Stop();
        }
        private void turn_right()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Start(1000, 0.4);
            RightMotor.Stop();
        }
        #endregion
        #region Initialize
        private async void btnInitialize_Click(object sender, RoutedEventArgs e)
        {
            if (LightningProvider.IsLightningEnabled)
            {
                LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
            }

            gpioController = await GpioController.GetDefaultAsync();
            if (gpioController == null)
                return;

            pwmControllers = await PwmController.GetControllersAsync(LightningPwmProvider.GetPwmProvider());
            if (pwmControllers == null)
                return;
            LeftMotor = new MotorControl(gpioController, pwmControllers[1]);
            LeftMotor.Initialize(LEFTINA, LEFTINB, LEFTPWM);
            RightMotor = new MotorControl(gpioController, pwmControllers[1]);
            RightMotor.Initialize(RIGHTINA, RIGHTINB, RIGHTPWM);
        }
        #endregion
        #region Forward
        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Forward(1000, 0.3);
            RightMotor.Forward(1000, 0.3);
        }
        private void turn_forward()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Forward(1000, 0.3);
            RightMotor.Forward(1000, 0.3);
        }
        #endregion
        #region Back
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Backward(1000,0.4);
            RightMotor.Backward(1000,0.4);
        }
        private void turn_back()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Backward(1000, 0.4);
            RightMotor.Backward(1000, 0.4);
        }
        #endregion
        #region Stop
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Stop();
            RightMotor.Stop();
        }
        #endregion

        #region Tracker Sensor

        private ITrackingSensor trackerSensor1;
        private ITrackingSensor trackerSensor2;
        private ITrackingSensor trackerSensor3;
        private ITrackingSensor trackerSensor4;
        private ITrackingSensor trackerSensor5;
        private void btnTrackerInitialize_Click(object sender, RoutedEventArgs e)
        {
            trackerSensor1 = new TrackingSensor(5);
            trackerSensor1.Initialize();
            trackerSensor1.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor2 = new TrackingSensor(17);
            trackerSensor2.Initialize();
            trackerSensor2.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor3 = new TrackingSensor(22);
            trackerSensor3.Initialize();
            trackerSensor3.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor4 = new TrackingSensor(23);
            trackerSensor4.Initialize();
            trackerSensor4.InterruptHandler += TrackerSensor_InterruptHandler;

            trackerSensor5 = new TrackingSensor(27);
            trackerSensor5.Initialize();
            trackerSensor5.InterruptHandler += TrackerSensor_InterruptHandler;
        }

        private void btnTrackerUpdate_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("========================== btnTrackerUpdate_Click ================================ ");

            var status1 = trackerSensor1.DetectStatus();
            var number1 = trackerSensor1.PinNumber;
            tbTrackerSensor1.Text = string.Format("Track sensor ={0};Track sensor ={1}", status1, number1);
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

        private bool fLLFS = false;
        private bool fLRFS = false;
        private bool fMFS = false;
        private bool fRLFS = false;
        private bool fRRFS = false;
        private void TrackerSensor_InterruptHandler(object sender, TrackingSensorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Environment.CurrentManagedThreadId);

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(500);
            //timer.Tick += Timer_Tick;
            //timer.Start();
            //System.Diagnostics.Debug.WriteLine("*************************** trackersensor_interrupthandler **************************** ");
            var tracker = sender as ITrackingSensor;
            switch (tracker.PinNumber)
            {
                case 4:
                    // todo: turn leftforward hard
                    //if(status1 == trackersensor1.detectstatus())
                    //system.diagnostics.debug.writeline("turn left");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fLLFS = true; }
                    else if(TrackingSensorStatus.Inactive == e.Status)
                    { fLLFS = false; }
                    break;
                case 6:
                    // todo: turn leftforward hard
                    //system.diagnostics.debug.writeline("turn leftforward");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fLRFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fLRFS = false; }
                    break;
                case 22:
                    // todo: slowforward
                    //system.diagnostics.debug.writeline("slowforward");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fMFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fMFS = false; }
                    break;
                case 23:
                    // todo: turn rightforward hard
                    //system.diagnostics.debug.writeline("turn rightforward");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fRLFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fRLFS = false; }
                    break;
                case 27:
                    // todo: turn right hard
                    //system.diagnostics.debug.writeline("turn right");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fRRFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fRRFS = false; }
                    break;
                default:
                    //system.diagnostics.debug.writeline("stop");
                    fLLFS = false;
                    fLRFS = false;
                    fMFS = false;
                    fRLFS = false;
                    fRRFS = false;
                    break;
            }

            System.Diagnostics.Debug.WriteLine("track sensor " + tracker.PinNumber + ", " + e.Status);

            //Task.Delay(100).Wait();

            //if (tracker.DetectStatus == Active)
            //{

            //}
        }

        #endregion

        private void btnTrackerStart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("*************************** trackersensor_detectstatus **************************** ");
            //var tracker = sender as ITrackingSensor;

            //var status1 = trackerSensor1.DetectStatus();
            //var number1 = trackerSensor1.PinNumber;
            //tbTrackerSensor1.Text = string.Format("Track sensor ={0};Track sensor ={1}", status1, number1);
            //System.Diagnostics.Debug.WriteLine("Track sensor ={0};Track sensor ={1}", number1, status1);
        }


        #region SmartTrack
        private int flag; 
        private void btnTrack_Click(object sender, RoutedEventArgs e)
        {

            //if (!((fLLFS) || (fLRFS) || (fMFS) || (fRLFS) || (fRRFS)))//没有找到黑线的情况下
            //{
            //    LeftMotor.Start(1000, 0.4);
            //    RightMotor.Stop();
            //    while (!((fLLFS) || (fLRFS) || (fMFS) || (fRLFS) || (fRRFS)))//在没有找到黑线的情况下，寻找黑线
            //    {
            //        Task.Delay(1).Wait();//找到目标黑线跳出
            //    }
            //}

            //if (fLRFS || fMFS || fRLFS)//第2第3个第4个寻线传感器寻到线
            //{
            //    LeftMotor.Forward(1000, 0.3);
            //    RightMotor.Forward(1000, 0.3);
            //    while (fLRFS || fMFS || fRLFS)
            //    {
            //        Task.Delay(1).Wait();//跑出黑线跳出
            //    }

            //}

            //else if (fLLFS || fLRFS)//传感器1和传感器2寻到线
            //{
            //    LeftMotor.Stop();//左转弯快速接触黑线
            //    RightMotor.Start(1000, 0.4);
            //    Task.Delay(200).Wait();
            //    while (!(fLLFS || fLRFS))
            //    {
            //        if ((fLRFS && fMFS) || (fMFS && fRLFS))
            //        {
            //            LeftMotor.Start(1000, 0.4);//到黑线中间右转调整方向
            //            RightMotor.Stop();
            //            break;

            //        }
            //    }
            //}
            //else if (fRRFS || fRLFS)//传感器4和传感器5寻到线
            //{
            //    LeftMotor.Start(1000, 0.4);//右转弯快速接触黑线
            //    RightMotor.Stop();
            //    Task.Delay(200).Wait();
            //    while (!(fRRFS || fRLFS))
            //    {
            //        if ((fLRFS && fMFS) || (fMFS && fRLFS))
            //        {
            //            RightMotor.Start(1000, 0.4);//到黑线中间左转调整方向
            //            LeftMotor.Stop();
            //            break;
            //        }
            //    }
            //}
            //else if (fMFS || fLRFS)//传感器3和传感器2寻到线
            //{
            //    LeftMotor.Start(1000, 0.2);//左前方前行
            //    RightMotor.Start(1000, 0.4);
            //    Task.Delay(200).Wait();
            //    while (!(fLLFS || fLRFS))
            //    {
            //        if ((fLRFS && fMFS) || (fMFS && fRLFS))
            //        {
            //            LeftMotor.Start(1000, 0.4);//到黑线中间右转调整方向
            //            RightMotor.Stop();
            //            break;

            //        }
            //    }
            //}
            //else if (fMFS || fRLFS)//传感器3和传感器4寻到线
            //{
            //    LeftMotor.Start(1000, 0.4);//右前方前行
            //    RightMotor.Start(1000, 0.2);
            //    Task.Delay(200).Wait();
            //    while (!(fRRFS || fRLFS))
            //    {
            //        if ((fLRFS && fMFS) || (fMFS && fRLFS))
            //        {
            //            RightMotor.Start(1000, 0.4);//到黑线中间左转调整方向
            //            LeftMotor.Stop();
            //            break;
            //        }
            //    }
            //}
            if (fLLFS|| fLRFS)
            { flag = 1; }
            else if (fRRFS|| fRLFS)
            { flag = 2; }
            else if ((!fLRFS) & (!fMFS) & (!fRLFS))
            { flag = 3; }
            else flag = 0;
            switch (flag)
            {
                case 0:
                    turn_forward();
                    break;
                case 1:
                    turn_left();
                    break;
                case 2:
                    turn_right();
                    break;
                case 3:
                    turn_back();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
