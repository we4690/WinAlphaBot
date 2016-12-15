using Microsoft.IoT.Lightning.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Devices.Pwm;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

            btnInitialize_Click(null, null);
        }


        private async void btnInitialize_Click(object sender, RoutedEventArgs e)
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
                var servoGpioPin = pwmController.OpenPin(5);

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

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
