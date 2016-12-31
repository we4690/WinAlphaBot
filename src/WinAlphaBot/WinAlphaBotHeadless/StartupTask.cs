using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using InfraredSensorLib;
using Windows.Devices.Gpio;
using MotorControlLib;
using Windows.Devices.Pwm;
using Microsoft.IoT.Lightning.Providers;
using Windows.Devices;
using TrackingSensorLib;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace WinAlphaBotHeadless
{
    public sealed class StartupTask : IBackgroundTask
    {
        #region Private members

        private GpioController gpioController;
        private GpioPin gpioPin;
        private IMotorControl LeftMotor;
        private IMotorControl RightMotor;
        private const int LEFTINA = 20;
        private const int LEFTINB = 21;
        private const int LEFTPWM = 13;
        private const int RIGHTINA = 6;
        private const int RIGHTINB = 26;
        private const int RIGHTPWM = 12;
        private IReadOnlyList<PwmController> pwmControllers;

        #endregion

        private enum AlphaBotState : byte
        {
            State1 = 0x00,
            State2 = 0x01,
            State3 = 0x02,
            State4 = 0x04,
            State5 = 0x08,
            State6 = 0x10,
        }

        private AlphaBotState prevState;
        private AlphaBotState currState;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //
            //var gpio = GpioController.GetDefault();
            //var motorControl = new MotorControl();

            //motorControl.Initialize();

            //motorControl.Start();

            //motorControl.Stop();

            //var infraredSensor = new InfraredSensor();

            //infraredSensor.Initialize();

            //infraredSensor.InterruptHandler += (o, e) =>
            //{
            //    if(e.IsHigh)
            //    {
            //        //TODO:
            //        motorControl.TurnLeft();
            //    }
            //    else
            //    {
            //        //TODO:
            //        motorControl.TurnRight();
            //    }
            //};
            int flag = 0;

            // Initialize MotorControllers
            MotorInitialize();

            // Initialize sensor trackers
            TrackerInitialize();



            if (fLLFS || fLRFS)
            {
                flag = 1;
            }
            else if (fRRFS || fRLFS)
            {
                flag = 2;
            }
            else if ((!fLRFS) & (!fMFS) & (!fRLFS))
            {
                flag = 3;
            }
            else flag = 0;
            switch (flag)
            {
                case 0:
                    //turn_forward();
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

        #region MotorInitialize
        private async void MotorInitialize()
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

        #region Direction Control
        private void turn_left()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Stop();
            RightMotor.Start(1000, 0.4);
        }

        private void turn_right()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Start(1000, 0.4);
            RightMotor.Stop();
        }
        private void turn_forward()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Forward(1000, 0.3);
            RightMotor.Forward(1000, 0.3);
        }
        private void turn_back()
        {
            if (gpioController == null || pwmControllers == null)
                return;
            LeftMotor.Backward(1000, 0.4);
            RightMotor.Backward(1000, 0.4);
        }
        #endregion

        #region TrackerSensor

        private ITrackingSensor trackerSensor1;
        private ITrackingSensor trackerSensor2;
        private ITrackingSensor trackerSensor3;
        private ITrackingSensor trackerSensor4;
        private ITrackingSensor trackerSensor5;
        private void TrackerInitialize()
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

        private void TrackerUnInitialize()
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

            // Save previous state
            prevState = currState;

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
                    else if (TrackingSensorStatus.Inactive == e.Status)
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

                // TODO: currState = AlphaBotState.State5;
                case 22:
                    // todo: slowforward
                    //system.diagnostics.debug.writeline("slowforward");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fMFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fMFS = false; }
                    break;

                // TODO: currState = AlphaBotState.State5;
                case 23:
                    // todo: turn rightforward hard
                    //system.diagnostics.debug.writeline("turn rightforward");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fRLFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fRLFS = false; }
                    break;

                // TODO: currState = AlphaBotState.State5;
                case 27:
                    // todo: turn right hard
                    //system.diagnostics.debug.writeline("turn right");
                    if (TrackingSensorStatus.Active == e.Status)
                    { fRRFS = true; }
                    else if (TrackingSensorStatus.Inactive == e.Status)
                    { fRRFS = false; }
                    break;

                // TODO: currState = AlphaBotState.State5;
                default:
                    //system.diagnostics.debug.writeline("stop");
                    fLLFS = false;
                    fLRFS = false;
                    fMFS = false;
                    fRLFS = false;
                    fRRFS = false;
                    break;
            }


            // State Machine
            switch (currState)
            {
                case AlphaBotState.State1:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                case AlphaBotState.State2:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                case AlphaBotState.State3:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                case AlphaBotState.State4:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                case AlphaBotState.State5:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                case AlphaBotState.State6:
                    if (prevState == AlphaBotState.State6)
                        LeftMotor.TurnLeft();
                    else if (prevState == AlphaBotState.State2)
                        RightMotor.TurnLeft();
                    else
                        Fault();
                    break;
                default:
                    Fault();
                    break;
            }


            System.Diagnostics.Debug.WriteLine("track sensor " + tracker.PinNumber + ", " + e.Status);
        }

        private void Fault()
        {

        }

        #endregion

    }
}
