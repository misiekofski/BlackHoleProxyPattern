using System;
using BlackHoleProxyPattern.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.Network;

namespace BlackHoleProxyPattern
{
    public class SeleniumBlackHoleProxyTest
    {
        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        { 
            _driver = new ChromeDriver();
            var session = _driver.CreateDevToolsSession();
            
            var blockedUrlSettings = new SetBlockedURLsCommandSettings();
            blockedUrlSettings.Urls = new string[]
            {
                "http://automationpractice.com/img/p/1/6/16-large_default.jpg", 
                "http://automationpractice.com/modules/blockbanner/img/sale70.png",
            };
            
            session.Network.SetBlockedURLs(blockedUrlSettings);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
        }

        [Test]
        public void TestFunctionalityWithBlockedImages()
        {
            var homePage = new HomePage(_driver);
            homePage.SearchProduct("Yellow");

            var resultsPage = new ResultsPage(_driver);
            resultsPage.SelectNthProduct(2);

            var productPage = new ProductPage(_driver);
            productPage.AddProductToCart();
            productPage.ProceedToCheckout();

            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}