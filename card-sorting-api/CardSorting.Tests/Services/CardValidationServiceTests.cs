using CardSorting.API.Interfaces;
using CardSorting.API.Models;
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
            var cards = new List<Card>
            {
                new Card { Rank = "4", Suit = 'H' },
                new Card { Rank = "2", Suit = 'D' }
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
            var cards = new List<Card>();

            //Act
            var result = _validationService.ValidateCards(cards);

            //Assert
            Assert.False(result);
        }
    }
}
