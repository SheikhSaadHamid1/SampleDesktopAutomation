using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDesktop.Utilities
{
    class Common
    {
        private static WebDriverWait wait;




        public static void EnterTextByAccessibilityID(WindowsDriver<WindowsElement> currentSession, string locator, string text)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5));
            WindowsElement element = wait.Until(ele => currentSession.FindElementByAccessibilityId(locator));
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterTextByAccessibilityID(WindowsDriver<WindowsElement> currentSession, WindowsElement element, string text)
        {

            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterTextByName(WindowsDriver<WindowsElement> currentSession, WindowsElement element, string text)
        {

            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public static void EnterTextByName(WindowsDriver<WindowsElement> currentSession, string locator, string text)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            WindowsElement element = wait.Until(ele => currentSession.FindElementByName(locator));
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickElementByAccessibilityID(WindowsDriver<WindowsElement> currentSession, string locator)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            WindowsElement element = wait.Until(ele => currentSession.FindElementByAccessibilityId(locator));
            element.Click();


        }

        public static void ClickElementByName(WindowsDriver<WindowsElement> currentSession, string locator)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            WindowsElement element = wait.Until(ele => currentSession.FindElementByName(locator));
            element.Click();

        }

        public static void ClickElementByClassName(WindowsDriver<WindowsElement> currentSession, string locator)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            WindowsElement element = wait.Until(ele => currentSession.FindElementByClassName(locator));
            element.Click();

        }

        public static bool ValidateElementIsSelectedByAccessibilityId(WindowsDriver<WindowsElement> currentSession, string locator)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            bool isElementSelected = false;
            WindowsElement element = wait.Until(ele => currentSession.FindElementByAccessibilityId(locator));
            if (element.Selected)
            {
                isElementSelected = true;
            }
            return isElementSelected;

        }

        public static bool ElementExistsByName(WindowsDriver<WindowsElement> currentSession, string locator)
        {
            wait = new WebDriverWait(currentSession, TimeSpan.FromSeconds(5)); //todo: Value to be retrieved from Config File
            bool isElementExists = false;
            var element = wait.Until(ele => currentSession.FindElementsByName(locator));
            if (element.Count > 0)
            {
                isElementExists = true;

            }

            return isElementExists;
        }

        public static bool isElementEnabled(WindowsDriver<WindowsElement> currentSession, WindowsElement element)
        {
            bool isElementEnabled = false;
            if (element.Enabled)
            {
                isElementEnabled = true;
            }

            return isElementEnabled;
        }

        public static bool IsElementDisplayed(WindowsElement element)
        {
            bool isElementDisplayed = false;
            if (element.Displayed)
            {
                isElementDisplayed = true;
            }
            return isElementDisplayed;
        }


    }
}
