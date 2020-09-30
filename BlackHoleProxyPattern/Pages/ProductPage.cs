using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BlackHoleProxyPattern.Pages
{
    public class ProductPage : BasePage
    {
        private By addToCartButtonLocator => By.Name("Submit");
        private IWebElement AddToCartButton => Driver.FindElement(addToCartButtonLocator);

        private By proceedToCheckoutButtonLocator => By.CssSelector("a.button-medium");
        private IWebElement ProceedToCheckoutButton => Driver.FindElement(proceedToCheckoutButtonLocator);

        public void AddProductToCart()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(e => AddToCartButton.Displayed);
            AddToCartButton.Click();
        }
        
        public void ProceedToCheckout()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(e => ProceedToCheckoutButton.Displayed);
            ProceedToCheckoutButton.Click();
        }

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }
    }
}