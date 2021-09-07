using System.Collections.ObjectModel;

namespace Finance.Tests.UI.PageObject
{
    using OpenQA.Selenium;

    public class HomePage
    {
        private readonly IWebDriver _webDriver;
        private const string PageUrl = "http://localhost:4200/";

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateTo()
        {
            _webDriver.Navigate().GoToUrl(PageUrl);
        }

        public CreditorListPage ClickCreditorLink()
        {
            _webDriver.FindElement(By.Id("creditor")).Click();
            return new CreditorListPage(_webDriver);
        }
    }
}