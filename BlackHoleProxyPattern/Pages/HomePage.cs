using System;
using OpenQA.Selenium;

namespace BlackHoleProxyPattern.Pages
{
    public class HomePage : BasePage
    {
        private By _searchInputLocator => By.Id("search_query_top");
        private IWebElement SearchInput => Driver.FindElement(_searchInputLocator);

        public void SearchProduct(string product)
        {
            SearchInput.SendKeys(product);
            SearchInput.SendKeys(Keys.Enter);
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
    }
}