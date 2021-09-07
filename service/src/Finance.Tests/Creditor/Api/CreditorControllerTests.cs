using System.Net.Http;
using System.Text;
using Finance.Application.Creditor;
using Newtonsoft.Json;

namespace Finance.Tests.Creditor.Api
{
    using Infrastructure;
    using Restaurant.Tests.Infrastructure.Api;
    using System.Collections.Specialized;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class CreditorControllerTests
        : ControllerBaseTest<FixtureBase>
    {
        public CreditorControllerTests(FixtureBase fixture)
            : base(fixture)
        {
        }

        private string Path => "creditor";

        [Fact]
        public async Task ShouldCreditorBeCreated()
        {
            // Arrange
            var expectedStatusCode = HttpStatusCode.OK;

            var dto = new RegisterCreditorDto
            {
                Name = "Creditor Name"
            };

            // Act
            var response = await HttpClient
                .PostAsync(requestUri: GetUri(path: $"{Path}"),
                    content: new StringContent(JsonConvert.SerializeObject(dto), Encoding.Default, "application/json"));

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }
    }
}