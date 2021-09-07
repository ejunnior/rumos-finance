namespace Finance.Tests.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Api;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Finance.Api;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;

    public class FixtureBase
    {
        public static readonly Uri ApiHost = new Uri("http://localhost.com");
        private readonly TestServer _apiServer;

        public FixtureBase()
        {
            _apiServer = CreateTestServer();
        }

        public HttpClient CreateClient()
        {
            var client = _apiServer.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(10);

            return client;
        }

        private TestServer CreateTestServer()
        {
            var builder = new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder()
                    .Build())
                .ConfigureAppConfiguration((context, config) =>
                {
                    context
                        .HostingEnvironment
                        .EnvironmentName = "Test";
                })
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureTestServices(services =>
                {
                    services
                        .AddControllers()
                        .AddApplicationPart(typeof(Startup).Assembly);
                })
                .UseStartup(typeof(ApiTestStartup));

            return new TestServer(builder);
        }
    }
}