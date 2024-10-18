using CardSorting.API.Interfaces;
using CardSorting.API.Models;
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
            var cards = new List<Card>
            {
                new Card { Rank = "3", Suit = 'C' },
                new Card { Rank = "J", Suit = 'S' },
                new Card { Rank = "2", Suit = 'D' },
                new Card { SpecialType = "PT" },
                new Card { Rank = "10", Suit = 'H' },
                new Card { Rank = "K", Suit = 'H' },
                new Card { Rank = "8", Suit = 'S' },
                new Card { SpecialType = "4T" },
                new Card { Rank = "A", Suit = 'C' },
                new Card { Rank = "4", Suit = 'H' },
                new Card { SpecialType = "RT" },
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
            var cards = new List<Card>();

            //Act
            var result = _cardSorter.SortCards(cards);

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SortCards_ShouldHandleSingleCard()
        {
            //Arrange
            var cards = new List<Card> { new Card { Rank = "A", Suit = 'S' } };

            //Act
            var result = _cardSorter.SortCards(cards);

            //Assert
            Assert.Single(result);
            Assert.Equal("AS", result.First());
        }
    }
}
