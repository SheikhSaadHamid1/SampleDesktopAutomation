using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Configurations
{
    class ExtentManager : Base
    {

        #region Fields
        private static readonly string TestFolderPath = @"Sample Path";
        #endregion

        #region Methods

        private static ExtentReports CreateInstance()
        {
            string reportPath = TestFolderPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.ReportName = "Report Name";
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.DocumentTitle = "Automation Report";
            htmlReporter.Config.Theme = Theme.Dark;

            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(htmlReporter);
           
            ExtentReports.AddSystemInfo("Environment", "Windows 10");

            return ExtentReports;
        }

        public static ExtentReports GetInstance()
        {
            if (ExtentReports == null)
                CreateInstance();
            return ExtentReports;
        }

        public static ExtentTest CreateParentTest(string className, string description = null)
        {
            ParentTest = GetInstance().CreateTest(className, description);
            return ParentTest;
        }

        public static ExtentTest CreateTest(string testName, string description = null)
        {
            ExtentTest = ParentTest.CreateNode(testName, description);
            return ExtentTest;
        }

        #endregion
    }
}
