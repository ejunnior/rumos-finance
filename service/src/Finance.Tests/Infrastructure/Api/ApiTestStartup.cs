namespace Finance.Tests.Infrastructure.Api
{
    using Finance.Api;
    using Microsoft.Extensions.Configuration;

    public class ApiTestStartup : Startup
    {
        public ApiTestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}