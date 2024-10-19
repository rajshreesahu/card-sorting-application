using CardSorting.API.Interfaces;
using CardSorting.API.Helpers;

namespace CardSorting.API.Services
{
    public class CardValidationService: ICardValidationService
    {
        private readonly ILogger<CardValidationService> _logger;
        public CardValidationService(ILogger<CardValidationService> logger)
        {
            _logger = logger;
        }

        public bool ValidateCards(List<string> cards, out string errorMessage)
        {
            errorMessage = string.Empty;

            //No Cards received
            if (cards == null || cards.Count == 0)
            {
                _logger.LogWarning("No cards received.");
                errorMessage = "No cards received.";
                return false;
            }

            //Invalid card format
            foreach (var card in cards)
            {
                if (!CardHelper.IsValidCard(card))
                {
                    _logger.LogWarning($"Invalid card input received: {card}");
                    errorMessage = $"Invalid card input received: {card}";
                    return false;
                }
            }

            _logger.LogInformation("Validated {Count} cards.", cards.Count);
            return true;
        }

    }
}
