using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testmachine
{
    [TestClass]
    public class Test_Logins
    {
        private static IWebDriver driver;
        private static string siteUrl = "http://statsmachine.gear.host/";

        [TestInitialize]
        public void InitTests() {
            try
            {
                ChromeOptions chromeoptions = new ChromeOptions();
                chromeoptions.AddArgument("--start-maximized");
                driver = new ChromeDriver(chromeoptions);
                //driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 5);
                //driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                
            }
            catch (Exception ex)
            {
                driver.Dispose();
                throw ex;
            }
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            driver.Dispose();
        }
        
        [TestMethod]
        public void TestSiteUrl()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,10));
            driver.Url = siteUrl;
            wait.Until(d => String.IsNullOrEmpty(d.Url) == false);
            Assert.IsTrue(driver.Url.Equals(siteUrl));
        }

        
    }
}
