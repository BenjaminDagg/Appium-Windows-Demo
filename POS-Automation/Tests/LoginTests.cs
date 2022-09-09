using NUnit.Framework;
using System;
using System.Threading;

namespace POS_Automation
{
    public class LoginTests : BaseTest
    {
        private LoginPage _loginPage;
        private DeviceManagementPage _deviceManagementPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(driver);
            _deviceManagementPage = new DeviceManagementPage(driver);
        }

        [Test]
        public void Test1()
        {

            _loginPage.Login("user1", "Diamond1#");

            Thread.Sleep(1000);

            _deviceManagementPage.DisplayDeviceList();

            Assert.Pass();
        }
    }
}