using AventStack.ExtentReports;
using NUnit.Framework;
using SampleDesktop.Configurations;

namespace SampleDesktop
{
    public class Tests : Base
    {
        
        [Test]
        public void Test1()
        {
            ExtentTest = ExtentReports.CreateTest("Sample Test");
            ExtentTest.Log(Status.Info, ("Passing a Sample Test."));
            Assert.Pass();
        }
    }
}