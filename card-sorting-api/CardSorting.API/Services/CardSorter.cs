using CardSorting.API.Interfaces;
using CardSorting.API.Models;

namespace CardSorting.API.Services
{
    public class CardSorter : ICardSorter
    {
        private static readonly List<string> specialCardsOrder = new List<string> { "4T", "2T", "ST", "PT", "RT" };
        private static readonly Dictionary<char, int> suitPriority = new Dictionary<char, int> { { 'D', 1}, { 'S', 2 }, { 'C', 3 }, { 'H', 4 } };
        private static readonly Dictionary<string, int> rankPriority = new Dictionary<string, int>
        {
            { "2", 2}, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6}, { "7", 7 },
            { "8", 8}, { "9", 9 }, { "10", 10 }, { "J", 11 }, { "Q", 12}, { "K", 13 }, { "A", 14 }
        };

        private readonly ILogger<CardSorter> _logger;
        public CardSorter(ILogger<CardSorter> logger)
        {
            _logger = logger;
        }

        public List<string> SortCards(List<Card> cards)
        {
            _logger.LogInformation("Starting to sort {Count} cards.", cards.Count);
            
            var sorted = cards.OrderBy(card =>
            {
                if(card.SpecialType != null && specialCardsOrder.Contains(card.SpecialType))
                {
                    _logger.LogInformation("Special Card {Card} found: ", card.SpecialType);
                    return (specialCardsOrder.IndexOf(card.SpecialType), -1, 1);
                }
                var rank = card.Rank;
                var suit = card.Suit;
                return (specialCardsOrder.Count + 1, suitPriority[suit], rankPriority[rank]);
            }).Select(card => card.SpecialType ?? $"{card.Rank}{card.Suit}").ToList();

            _logger.LogInformation("Sorting Complete.");
            return sorted;
        }
    }
}
