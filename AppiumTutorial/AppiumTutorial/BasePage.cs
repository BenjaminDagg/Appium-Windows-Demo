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
    public abstract class BasePage
    {
        protected WindowsDriver<WindowsElement> driver;

        public BasePage(WindowsDriver<WindowsElement> _driver)
        {
            driver = _driver;
        }
    }
}
