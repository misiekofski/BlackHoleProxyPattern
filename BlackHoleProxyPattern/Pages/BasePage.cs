using OpenQA.Selenium;

namespace BlackHoleProxyPattern.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}