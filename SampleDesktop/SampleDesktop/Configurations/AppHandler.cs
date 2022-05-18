using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Configurations
{
    public class AppHandler
    {

        #region Fields
        private static string _appFolderPath = @"TestPath";
        private static List<string> _appDirectories = null;
        private static WindowsDriver<WindowsElement> _desktopSession;
        private static WebDriverWait wait;
        private readonly string _appiumDriverUri = "http://127.0.0.1:4723";
        private static Process _processId;
        public static ReadOnlyCollection<WindowsElement> appWindows;

        #endregion
        #region Constructor
        public AppHandler(WindowsDriver<WindowsElement> desktopSession)
        {
            _desktopSession = desktopSession;
        }
        #endregion


        #region Methods
        public void SampleMethod1()
        {
            Console.WriteLine("Dummy code");
        }

        public void SampleMethod2()
        {
            Console.WriteLine("Dummy code");
        }

        public void SampleMethod3()
        {
            Console.WriteLine("Dummy code");
        }
        #endregion 




    }
}
