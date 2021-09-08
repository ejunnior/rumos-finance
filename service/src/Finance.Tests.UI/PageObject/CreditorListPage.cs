using OpenQA.Selenium;

namespace Finance.Tests.UI.PageObject
{
    public class CreditorListPage
    {
        private readonly IWebDriver _webDriver;
        private const string PageUrl = "http://localhost:4200/creditor";

        public CreditorListPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateTo()
        {
            _webDriver.Navigate().GoToUrl(PageUrl);
        }

        public CreditorCreatePage ClickCreateLink()
        {
            _webDriver.FindElement(By.Id("create")).Click();
            return new CreditorCreatePage(_webDriver);
        }
    }
}