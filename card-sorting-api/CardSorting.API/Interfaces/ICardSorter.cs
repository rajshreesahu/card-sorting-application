namespace CardSorting.API.Interfaces
{
    public interface ICardSorter
    {
        List<string> SortCards(List<string> cards);
    }
}
