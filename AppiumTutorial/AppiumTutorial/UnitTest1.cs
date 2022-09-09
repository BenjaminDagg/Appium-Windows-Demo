using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;   //DesiredCapabilities
using System;
using Appium;
using OpenQA.Selenium.Appium;   //Appium Options
using System.Threading;
using OpenQA.Selenium;

//https://github.com/jamesmcroft/uwp-appium-pop-example/tree/master/src/Uwp.Appium.PopExample.Alarms

namespace AppiumTutorial
{
    public class Tests
    {
        private string DriverUrl = "http://127.0.0.1:4723";         //found by starting WinAppDriver.exe
        private string AppPath = @"C:\Windows\System32\notepad.exe";
        private string AppDriverPath = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
        private WindowsDriver<WindowsElement> AppSession;

        public WindowsElement TextBoxMain
        {
            get
            {
                return AppSession.FindElementByName("Text Editor");
            }
        }

        private By FileMenuItem;

        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app",AppPath);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            this.AppSession = new WindowsDriver<WindowsElement>(new Uri(DriverUrl),appiumOptions);

            FileMenuItem = By.XPath("//MenuItem[@Name='File']");
        }


        [TearDown]
        public void EndTest()
        {
            //close session (app)
            if (AppSession != null)
            {
                AppSession.Close();
                AppSession.Quit();
            }
        }

        private static void StartWinAppDriver()
        {
           
        }

        [Test]
        public void Test1()
        {

            //WindowsElement textBoxMain = AppSession.FindElementByName("Text Editor");
            //textBoxMain.SendKeys("Test");

            TextBoxMain.SendKeys("Test text");
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [Test]
        public void Click_File()
        {
            AppSession.FindElement(FileMenuItem).Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void Close_File_Menu()
        {
            AppSession.FindElement(FileMenuItem).Click();
            Thread.Sleep(2000);
            AppSession.FindElement(FileMenuItem).Click();
        }
    }
}