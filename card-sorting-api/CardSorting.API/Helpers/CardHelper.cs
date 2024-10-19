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

        public static bool IsValidCard(string card)
        {
            //Special cards list
            var specialCards = new List<string> { "4T", "2T", "ST", "PT", "RT" };

            if (specialCards.Contains(card))
            {
                return true;
            }

            if (card.Length < 2 || card.Length > 3) return false;

            string validRanks = "23456789TJQKA";
            string validSuits = "CDHS";

            var rank = card.Length == 3 ? "10" : card[0].ToString();
            var suit = card[card.Length - 1];

            return (validRanks.Contains(rank) || rank == "10") && validSuits.Contains(suit);
        } 
    }
}
