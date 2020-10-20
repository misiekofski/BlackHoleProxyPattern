using System;
using System.Threading;
using BlackHoleProxyPattern.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.Network;

namespace BlackHoleProxyPattern
{
    public class SeleniumBlackHoleProxyTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        { 
            driver = new ChromeDriver();
            IDevTools devTools = driver as IDevTools;
            var session = devTools.CreateDevToolsSession();
            
            var blockedUrlSettings = new SetBlockedURLsCommandSettings();
            blockedUrlSettings.Urls = new string[]
            {
                "http://automationpractice.com/img/p/1/6/16-large_default.jpg", 
                "http://automationpractice.com/modules/blockbanner/img/sale70.png",
            };

            session.Network.Enable(new EnableCommandSettings());
            session.Network.SetBlockedURLs(blockedUrlSettings);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            Thread.Sleep(10000);
        }

        [Test]
        public void TestFunctionalityWithBlockedImages()
        {
            var homePage = new HomePage(driver);
            homePage.SearchProduct("Yellow");

            var resultsPage = new ResultsPage(driver);
            resultsPage.SelectNthProduct(2);

            var productPage = new ProductPage(driver);
            productPage.AddProductToCart();
            productPage.ProceedToCheckout();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}