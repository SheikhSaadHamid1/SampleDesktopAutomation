using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Common
{
    class CommonHelper
    {
        public static WindowsDriver<WindowsElement> DesktopSession;
        private static readonly string _appiumDriverUri = ConfigurationManager.AppSettings["appiumUri"];
        public static WindowsDriver<WindowsElement> Switch_Session()
        {
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", "Path of Application");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(_appiumDriverUri), appCapabilities);
            DesktopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //todo: Value to be retrieved from app.config

            return DesktopSession;
        }
    }
}
