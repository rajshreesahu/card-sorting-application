using CardSorting.API.Models;

namespace CardSorting.API.Interfaces
{
    public interface ICardSorter
    {
        List<string> SortCards(List<Card> cards);
    }
}
