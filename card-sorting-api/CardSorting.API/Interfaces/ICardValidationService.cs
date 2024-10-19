namespace CardSorting.API.Interfaces
{
    public interface ICardValidationService
    {
        bool ValidateCards(List<string> cards);
    }
}
