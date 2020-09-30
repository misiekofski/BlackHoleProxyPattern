using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BlackHoleProxyPattern.Pages
{
    public class ResultsPage : BasePage
    {
        private By productContainersLocator => By.CssSelector("div.product-container");
        private ReadOnlyCollection<IWebElement> ProductContainerList => Driver.FindElements(productContainersLocator);

        public void SelectNthProduct(int n)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(e => ProductContainerList.Count > 0);
            ProductContainerList[n-1].Click();
        }

        public ResultsPage(IWebDriver driver) : base(driver)
        {
        }
    }
}