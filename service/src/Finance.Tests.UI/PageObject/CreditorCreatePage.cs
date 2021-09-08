using OpenQA.Selenium;

namespace Finance.Tests.UI.PageObject
{
    public class CreditorCreatePage
    {
        private readonly IWebDriver _webDriver;
        private const string PageUrl = "http://localhost:4200/creditor/create";

        public CreditorCreatePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateTo()
        {
            _webDriver.Navigate().GoToUrl(PageUrl);
        }

        public CreditorCreatePage EnterCreditorName(string creditorName)
        {
            _webDriver.FindElement(By.Id("name")).SendKeys(creditorName);
            return this;
        }

        public CreditorListPage ClickCreateLink()
        {
            _webDriver.FindElement(By.Id("create")).Click();
            return new CreditorListPage(_webDriver);
        }
    }
}