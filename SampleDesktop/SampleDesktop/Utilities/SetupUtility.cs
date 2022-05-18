using OpenQA.Selenium.Appium.Windows;
using SampleDesktop.Common;
using SampleDesktop.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Utilities
{
    class SetupUtility
    {

        public static WindowsDriver<WindowsElement> DesktopSession = CommonHelper.Switch_Session();
        private readonly string _appiumDriverUri = "http://127.0.0.1:4723";
        public static Dictionary<string, AppHandler> appHandler = new Dictionary<string, AppHandler>();
       

        public void InitializeTest()
        {
            Console.WriteLine("Sample Method to Initialize Test");
        }
        
    }
}
