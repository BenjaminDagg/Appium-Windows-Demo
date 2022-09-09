using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;   //DesiredCapabilities
using System;
using Appium;
using OpenQA.Selenium.Appium;   //Appium Options
using System.Threading;
using OpenQA.Selenium;

namespace AppiumTutorial
{
    public abstract class BaseTest
    {
        protected WindowsDriver<WindowsElement> driver;

        public BaseTest()
        {
            
        }



        [SetUp]
        public void Setup()
        {
            SessionManager.Init();
            driver = SessionManager.Driver;
        }


        [TearDown]
        public void EndTest()
        {
            SessionManager.Close();
        }
    }
}
