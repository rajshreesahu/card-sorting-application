using CardSorting.API.Models;

namespace CardSorting.API.Interfaces
{
    public interface ICardValidationService
    {
        bool ValidateCards(List<Card> cards);
    }
}
