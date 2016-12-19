using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace InfraredLib
{
    public sealed class InfraredSensor : IInfraredSensor
    {
        //public EventHandler InterruptHandler
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        private GpioPin pinInputLeft;
        private GpioPin pinInputRight;
        private DispatcherTimer timer;

        public void Initialize()
        {

            GpioController gpio = GpioController.GetDefault();
            pinInputLeft = gpio.OpenPin(4);    //pin 7 
            pinInputRight = gpio.OpenPin(5);    //pi 29
            pinInputLeft.SetDriveMode(GpioPinDriveMode.Input);
            pinInputRight.SetDriveMode(GpioPinDriveMode.Input);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += detectVoltage;
            timer.Start();
            throw new NotImplementedException();
        }

        public void detectVoltage(object sender, object e)
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
    }
}
