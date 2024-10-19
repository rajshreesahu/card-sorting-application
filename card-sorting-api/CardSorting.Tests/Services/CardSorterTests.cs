using CardSorting.API.Interfaces;
using CardSorting.API.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CardSorting.Tests.Services
{
    public class CardSorterTests
    {
        private readonly ICardSorter _cardSorter;

        public CardSorterTests()
        {
            var loggerMock = new Mock<ILogger<CardSorter>>(); //Mock the logger
            _cardSorter = new CardSorter(loggerMock.Object);
        }

        [Fact]
        public void SortCards_ShouldReturnSortedCards_WhenValidInput()
        {
            //Arrange
            var cards = new List<string>
            {
                "3C", "JS", "2D", "PT", "10H", "KH", "8S", "4T", "AC", "4H", "RT"
            };

            //Act
            var result = _cardSorter.SortCards(cards);

            //Assert
            Assert.Equal("4T", result[0]);
            Assert.Equal("PT", result[1]); //Special card should come first
            Assert.Equal("RT", result[2]);
            Assert.Equal("2D", result[3]);
            Assert.Equal("8S", result[4]);
            Assert.Equal("JS", result[5]);
            Assert.Equal("3C", result[6]);
            Assert.Equal("AC", result[7]);
            Assert.Equal("4H", result[8]);
            Assert.Equal("10H", result[9]);
            Assert.Equal("KH", result[10]);
        }

        [Fact]
        public void SortCards_ShouldHandleEmptyList()
        {
            //Arrange
            var cards = new List<string>();

            //Act
            var result = _cardSorter.SortCards(cards);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SortCards_ShouldHandleSingleCard()
        {
            //Arrange
            var cards = new List<string> { "AS" };

            //Act
            var result = _cardSorter.SortCards(cards);

            //Assert
            Assert.Single(result);
            Assert.Equal("AS", result.First());
        }
    }
}
