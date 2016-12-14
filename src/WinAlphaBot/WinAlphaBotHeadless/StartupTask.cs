using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using MotorControlLib;
using InfraredLib;
using Windows.Devices.Gpio;

// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace WinAlphaBotHeadless
{
    public sealed class StartupTask : IBackgroundTask
    {
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
        }
    }
}
