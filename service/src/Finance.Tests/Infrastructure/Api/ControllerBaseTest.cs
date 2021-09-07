using Finance.Tests.Infrastructure;

namespace Restaurant.Tests.Infrastructure.Api
{
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using Infrastructure;
    using Microsoft.Data.SqlClient;
    using Xunit;

    [Collection(FixtureBaseCollection.Name)]
    public class ControllerBaseTest<TFixture>
        where TFixture : FixtureBase
    {
        private readonly TFixture _fixture;

        public ControllerBaseTest(TFixture fixture)
        {
            _fixture = fixture;

            HttpClient = _fixture.CreateClient();
        }

        protected HttpClient HttpClient { get; }

        protected virtual Uri GetUri(string path, NameValueCollection queryString = null)
        {
            var builder = new UriBuilder(FixtureBase.ApiHost)
            {
                Path = path
            };

            if (queryString != null)
            {
                builder.Query = queryString.ToQueryString();
            }

            return builder.Uri;
        }
    }
}