using java.lang;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MSTestOverview
{
    [TestClass]
    public class AlarmsAndClockTest
    {

        //Please change the path as per requirement
        static string winAPPDriverPath = @"C:\Users\shamid\source\repos\MSTestOverview\Windows Application Driver\WinAppDriver.exe"; //todo: to be managed through app.config and Directory Class
        
        

        static string _appiumURI = "http://127.0.0.1:4723";
        static WindowsDriver<WindowsElement> alarmClockSession;
        static WindowsDriver<WindowsElement> desktopSession;
        [ClassInitialize]
        public static void PrepareForTestingAlarms(TestContext testContext)
        {
            ProcessBuilder processBuilder = new ProcessBuilder(winAPPDriverPath).inheritIO();
            processBuilder.start();

            Thread.sleep(2000);

            Debug.WriteLine("Initializing Alarm Clock");


            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
            alarmClockSession = new WindowsDriver<WindowsElement>(new Uri(_appiumURI), options);
            alarmClockSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [TestInitialize]
        public void BeforeTest()
        {
            Debug.WriteLine("Method to be executed before Test Method");
        }

        [TestCleanup]
        public void AfterTest()
        {
            Debug.WriteLine("Method to be executed after Test Method");
        }
        
        
        [TestMethod, Priority(1)]
        public void TestAlarmClockLaunch()
        {
            Debug.WriteLine("Executing Test Method");
            Assert.AreEqual("Alarms & Clock", alarmClockSession.Title, false, $"Actual Title doesn't match: {alarmClockSession.Title}");


        }

       

        [TestMethod, Priority(2)]
        public void NavigateClockTab()
        {
            WindowsElement clockTab = alarmClockSession.FindElementByAccessibilityId("ClockButton");
            clockTab.Click();

            WindowsElement addClockButton = alarmClockSession.FindElementByAccessibilityId("AddClockButton");
            addClockButton.Click();
            WebDriverWait wait = new WebDriverWait(alarmClockSession, TimeSpan.FromSeconds(10));
            
            WindowsElement enterCityField = wait.Until(ele => alarmClockSession.FindElementByName("Enter a location"));
            enterCityField.Click();
            enterCityField.Clear();
            enterCityField.SendKeys("Lahore, Pakistan");
            enterCityField.SendKeys(Keys.Down);
            enterCityField.SendKeys(Keys.Enter);

            var clockTiles = wait.Until(ele => alarmClockSession.FindElementsByClassName("NamedContainerAutomationPeer"));
            bool isClockTileFound = false;
            foreach (var tile in clockTiles)
            {
                if (tile.Text.Contains("Lahore"))
                {
                    isClockTileFound = true;
                    Debug.WriteLine("Clock tile is found ");
                    break;
                }
            }

            Assert.IsTrue(isClockTileFound, "Clock tile not found");

            Actions action = new Actions(alarmClockSession);

            foreach (var tile in clockTiles)
            {
                if (tile.Text.Contains("Lahore"))
                {
                    action.MoveToElement(tile).Click().ContextClick().Build().Perform();
                  
                    WindowsElement deleteContextClick = alarmClockSession.FindElementByName("Delete");
                    deleteContextClick.Click();

                    break;
                }
            }


            



        }






        





        [ClassCleanup]
        public static void CloseAlarmClock()
        {
            
            if(alarmClockSession != null)
            {
                Debug.WriteLine("Closing alarm clock");
                //Holding thread for 2 seconds before closing alarm clock
                Thread.sleep(2000);
                alarmClockSession.Close();
            }
        }
    }
}
