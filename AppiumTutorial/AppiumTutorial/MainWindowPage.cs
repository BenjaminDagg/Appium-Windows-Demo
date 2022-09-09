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
    public class MainWindowPage : BasePage
    {
        
        private By FileMenuItem;
        private By TextBoxMain;

        public MainWindowPage(WindowsDriver<WindowsElement> _driver) : base(_driver)
        {
            FileMenuItem = By.XPath("//MenuItem[@Name='File']");
            TextBoxMain = By.Name("Text Editor");
            
        }


        public void Click_File()
        {
            driver.FindElement(FileMenuItem).Click();
        }


        public void EnterText(string text)
        {
            driver.FindElement(TextBoxMain).SendKeys(text);
        }
    }
}
