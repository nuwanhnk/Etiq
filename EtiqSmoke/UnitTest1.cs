using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EtiqSmoke
{
    [TestClass]
    public class EtiqLogin
    {
        private IWebDriver driver;
        private string etiqURL;

        [TestMethod]
        public void LogintoEtiq()
        {
            
            driver.Navigate().GoToUrl(etiqURL + "/");
            driver.FindElement(By.XPath("//*[@id='Username']")).SendKeys("dwa@tiqri.com");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("o9rms");
            driver.FindElement(By.XPath("//button[contains(text(),'Logg inn')]")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(true,driver.FindElement(By.XPath("//img[@id='E-tiqLogo']")).Displayed,"Login Successfull");
            
        }

        [TestCleanup()]
        public void TearDownTest()
        {
            driver.Close();

        }


        [TestInitialize()]
        public void SetupTest()
        {
            etiqURL = "https://www.e-tiq.no";

            driver = new ChromeDriver();

        }
    }
}
