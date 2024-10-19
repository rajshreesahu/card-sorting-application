using CardSorting.API.Interfaces;
using CardSorting.API.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CardSorting.Tests.Services
{
    public class CardValidationServiceTests
    {
        private readonly ICardValidationService _validationService;

        public CardValidationServiceTests()
        {
            var loggerMock = new Mock<ILogger<CardValidationService>>(); //Mock the logger
            _validationService = new CardValidationService(loggerMock.Object);
        }

        [Fact]
        public void ValidateCards_ShouldReturnTrue_WhenValidInput()
        {
            //Arrange
            var cards = new List<string>
            {
                "3C", "JS", "2D", "PT", "10H", "KH", "8S", "4T", "AC", "4H", "RT"
            };

            //Act
            var result = _validationService.ValidateCards(cards);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateCards_ShouldReturnFalse_WhenEmptyList()
        {
            //Arrange
            var cards = new List<string>();

            //Act
            var result = _validationService.ValidateCards(cards);

            //Assert
            Assert.False(result);
        }
    }
}
