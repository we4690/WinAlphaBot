using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml;
using PIDControllerLib;
using System.Threading.Tasks;

namespace PIDController.UWP.UnitTest
{
    [TestClass]
    public class PIDControllerTest
    {
        [TestMethod]
        public void ControlVariableTest()
        {
            var pidController = new PIDControllerLib.PIDController(.0, .005, .0, 1.0, .0);

            pidController.ProcessVariable = .0;
            pidController.Setpoint = .5;

            var startTime = DateTime.Now;

            double output = .0;
            for (int i = 0; i < 100; i++)
            {
                startTime = DateTime.Now;
                pidController.ProcessVariable = output;

                Task.Delay(10).Wait();
                output = pidController.ControlVariable(DateTime.Now - startTime);

                System.Diagnostics.Debug.WriteLine(output);
            }

            Assert.AreEqual(pidController.Setpoint, output, .001);
        }
    }
}
