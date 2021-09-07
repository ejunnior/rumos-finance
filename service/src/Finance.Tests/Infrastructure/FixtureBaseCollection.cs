using Xunit;

namespace Finance.Tests.Infrastructure
{
    [CollectionDefinition(Name)]
    public class FixtureBaseCollection : ICollectionFixture<FixtureBase>
    {
        public const string Name = nameof(FixtureBase);
    }
}