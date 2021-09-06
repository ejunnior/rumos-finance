namespace Finance.Tests.Creditor.Aggregates.CreditorAggregate
{
    using Finance.Domain.Creditor.Aggregates.CreditorAggregate;
    using Xunit;

    public class CreditorNameTests
    {
        [Fact]
        public void ShouldCreditorNameBeCreated()
        {
            // Arrange
            var expectedName = "Creditor Name";

            // Act
            var sut = CreditorName
                .Create(expectedName);

            // Assert
            Assert.Equal(expectedName, sut.Value.Value);
        }

        [Fact]
        public void ShouldCreditorNameNotBeCreated()
        {
            // Arrange
            var expectedName = string.Empty;

            // Act
            var sut = CreditorName
                .Create(expectedName);

            // Assert
            Assert.True(sut.IsFailure);
            Assert.Equal("Value is Required", sut.Error);
        }
    }
}