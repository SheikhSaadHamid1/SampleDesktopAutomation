using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SampleDesktop.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Configurations
{
    public class Base
    {

        public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string[] Path = BasePath.Split(new[] { "bin" }, StringSplitOptions.None);

        public static string[] PathApp =
            BasePath.Split(new[] { "Sample Application Path" }, StringSplitOptions.None);
        
        public static string AutoAppDirectory = PathApp[0];
        public static string PathDef = Path[0];
        public static Dictionary<string,AppHandler>appHandle;
        private static readonly string _appPath = @"Sample Path";
        private static string _appiumUri = "http://127.0.0.1:4723";
        public static WindowsDriver<WindowsElement> appSession;
       
        private readonly string _appiumDriverUri = "http://127.0.0.1:4723"; //todo: to be retrieved from config file
        public static ExtentReports ExtentReports;
        public static ExtentTest ExtentTest;
        public static ExtentTest ParentTest;



        [OneTimeSetUp]
        protected void InitializeTest()
        {
            SetupUtility utility = new SetupUtility();
            utility.InitializeTest();
            appHandle = SetupUtility.appHandler;

            

          
            Debug.WriteLine("Opening Application");
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", _appPath);
            appSession = new WindowsDriver<WindowsElement>(new Uri(_appiumUri), appOptions);
            appSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }

        [TearDown]
        public void AfterTest()
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            string stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : $"{TestContext.CurrentContext.Result.StackTrace}";
            Status logStatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;
            }

            ExtentTest.Log(logStatus, "Test ended with " + logStatus + stacktrace);
            ExtentReports.Flush();
        }

    }
}
