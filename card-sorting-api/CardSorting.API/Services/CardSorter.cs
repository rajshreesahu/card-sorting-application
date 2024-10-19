using CardSorting.API.Interfaces;
using CardSorting.API.Helpers;

namespace CardSorting.API.Services
{
    public class CardSorter : ICardSorter
    {
        private static readonly List<string> _specialCardsOrder = new List<string> { "4T", "2T", "ST", "PT", "RT" };
        private static readonly List<string> _suitPriority = new List<string> { "D", "S", "C", "H" };
        private static readonly List<string> _rankPriority = new List<string>
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };


        private readonly ILogger<CardSorter> _logger;
        public CardSorter(ILogger<CardSorter> logger)
        {
            _logger = logger;
        }

        public List<string> SortCards(List<string> cards)
        {
            _logger.LogInformation("Starting to sort {Count} cards.", cards.Count);
            
            var specialCards = cards.Where(c => _specialCardsOrder.Contains(c)).ToList();
            var normalCards = cards.Where(c => !_specialCardsOrder.Contains(c)).ToList();

            //Sort special cards based on the defined priority
            specialCards.Sort((x, y) => _specialCardsOrder.IndexOf(x).CompareTo(_specialCardsOrder.IndexOf(y)));

            //Sort normal cards by suit and rank
            normalCards.Sort((x, y) =>
            {
                //Split cards into rank and suit
                var rankX = CardHelper.GetRank(x);
                var suitX = CardHelper.GetSuit(x);
                var rankY = CardHelper.GetRank(y);
                var suitY = CardHelper.GetSuit(y);

                //Compare by suit first
                var suitComparison = _suitPriority.IndexOf(suitX).CompareTo(_suitPriority.IndexOf(suitY));
                if (suitComparison != 0)
                {
                    return suitComparison;
                }

                //if suits are same, compare by rank
                return _rankPriority.IndexOf(rankX).CompareTo(_rankPriority.IndexOf(rankY));
            });

            var sortedCards = specialCards.Concat(normalCards).ToList();
            return sortedCards;
        }
    }
}
