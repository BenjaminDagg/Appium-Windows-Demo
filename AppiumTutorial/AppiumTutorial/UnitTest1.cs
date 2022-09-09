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
    public class Tests : BaseTest
    {
        private MainWindowPage _mainWindow;

        public WindowsElement TextBoxMain
        {
            get
            {
                return driver.FindElementByName("Text Editor");
            }
        }

        private By FileMenuItem;

        public Tests() : base()
        {
            
            FileMenuItem = By.XPath("//MenuItem[@Name='File']");
        }

        [SetUp]
        public void Setup()
        {
            _mainWindow = new MainWindowPage(driver);
        }


        [TearDown]
        public void EndTest()
        {
            
        }


        [Test]
        public void Test1()
        {

            //WindowsElement textBoxMain = AppSession.FindElementByName("Text Editor");
            //textBoxMain.SendKeys("Test");

            _mainWindow.EnterText("Page object text");
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [Test]
        public void Click_File()
        {
            _mainWindow.Click_File();
            Thread.Sleep(5000);
        }

        [Test]
        public void Close_File_Menu()
        {
            driver.FindElement(FileMenuItem).Click();
            Thread.Sleep(2000);
            driver.FindElement(FileMenuItem).Click();
            Assert.Pass();
        }
    }
}