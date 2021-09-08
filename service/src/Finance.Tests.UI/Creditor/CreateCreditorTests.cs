using OpenQA.Selenium;

namespace Finance.Tests.UI.Creditor
{
    using Xunit;
    using OpenQA.Selenium.Chrome;
    using PageObject;

    public class CreateCreditorTests
    {
        [Fact]
        public void ShouldCreditorBeCreated()
        {
            // Arrange
            using (var driver = new ChromeDriver())
            {
                var expectedPageTitle = "Creditor List";

                var homePage = new HomePage(driver);

                homePage.NavigateTo();

                //Act
                homePage
                    .ClickCreditorLink()
                    .ClickCreateLink()
                    .EnterCreditorName("Creditor Name")
                    .ClickCreateLink();

                // Assert
                Assert.Equal(expectedPageTitle, driver.FindElement(By.Id("title")).Text);
            }
        }
    }
}