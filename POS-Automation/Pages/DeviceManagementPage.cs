using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;   //DesiredCapabilities
using System;
using Appium;
using OpenQA.Selenium.Appium;   //Appium Options
using System.Threading;
using OpenQA.Selenium;
using System.Collections;
using OpenQA.Selenium.Interactions;

//https://diamondgame.visualstudio.com/Diamond%20Game%20Portfolio/_git/AppDev_MOLite?path=/POS/POS/Modules/DeviceManagement/Views/DeviceManagementView.xaml&version=GBPOS_NewTheme&_a=contents

namespace POS_Automation
{
    public class DeviceManagementPage : BasePage
    {

        private By DeviceDataGrid;
        private ByAccessibilityId PromoTicketToggleButton;
        private By PromoConfirmationWindow;
        private ByAccessibilityId ConfirmationYesButton;
        private By SetAllOfflineButton;
        private By SetAllOnlineButton;

        public DeviceManagementPage(WindowsDriver<WindowsElement> _driver) : base(_driver)
        {
            driver = _driver;

            DeviceDataGrid = By.ClassName("DataGrid");
            PromoTicketToggleButton = new ByAccessibilityId("TogglePromoTicketBtn");
            PromoConfirmationWindow = By.Name("Please Confirm");
            ConfirmationYesButton = new ByAccessibilityId("Yes");
            SetAllOfflineButton = By.Name("Set All Offline");
            SetAllOnlineButton = By.Name("Set All Online");
        }


        public void ClickPromoTicketToggle()
        {
            WindowsElement promoButton = driver.FindElement(PromoTicketToggleButton);
            Console.WriteLine(promoButton.Text);
            driver.FindElement(PromoTicketToggleButton).Click();
            driver.FindElement(ConfirmationYesButton).Click();
        }


        public void EnablePromoTickets()
        {
            WindowsElement promoButton = driver.FindElement(PromoTicketToggleButton);
            
            if (promoButton.Text == "Turn Promo Ticket On")
            {
                promoButton.Click();
                driver.FindElement(ConfirmationYesButton).Click();
            }
        }


        public void DisablePromoTickets()
        {
            WindowsElement promoButton = driver.FindElement(PromoTicketToggleButton);

            if (promoButton.Text == "Turn Promo Ticket Off")
            {
                promoButton.Click();
                driver.FindElement(ConfirmationYesButton).Click();
            }
        }


        public void DisplayDeviceList()
        {
            
            WindowsElement deviceList = driver.FindElement(DeviceDataGrid);
            var rows = deviceList.FindElements(By.XPath(".//DataItem"));
            Console.WriteLine(rows.Count);
            
            foreach (var row in rows)
            {
                Console.WriteLine("============");
                var icon = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[1]"));
                
                //Console.WriteLine(icon.GetProperty("Foreground"));
                var machNo = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[2]")).Text;
                Console.WriteLine(machNo);

                var ipAddress = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[3]")).Text;
                Console.WriteLine(ipAddress);

                try
                {
                    var lastPlayed = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[4]")).Text;
                    Console.WriteLine("Last Played: " + lastPlayed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Last played not found");
                }

                try
                {
                    var transType = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[5]")).Text;
                    Console.WriteLine("Trans Type: " + transType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("trans type not found");
                }

                var description = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[6]")).Text;
                Console.WriteLine(description);

                var balance = row.FindElement(By.XPath("(.//*[@ClassName='DataGridCell'])[7]")).Text;
                Console.WriteLine(balance);
            }
           
        }
    }
}
