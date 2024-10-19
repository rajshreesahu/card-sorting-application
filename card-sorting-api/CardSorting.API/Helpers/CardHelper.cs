namespace CardSorting.API.Helpers
{
    public static class CardHelper
    {
        public static string GetRank(string card)
        {
            return card.Length == 3 ? card.Substring(0, 2) : card[0].ToString();
        }

        public static string GetSuit(string card)
        {
            return card.Last().ToString();
        }
    }
}
