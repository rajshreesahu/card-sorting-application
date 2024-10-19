using CardSorting.API.Interfaces;

namespace CardSorting.API.Services
{
    public class CardValidationService: ICardValidationService
    {
        private readonly ILogger<CardValidationService> _logger;
        public CardValidationService(ILogger<CardValidationService> logger)
        {
            _logger = logger;
        }

        public bool ValidateCards(List<string> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                _logger.LogWarning("No cards received.");
                return false;
            }
            _logger.LogInformation("Validated {Count} cards.", cards.Count);
            return true;
        }

    }
}
