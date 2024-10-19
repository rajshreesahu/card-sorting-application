namespace CardSorting.API.Models
{
    public class Card
    {
        public string Rank { get; set; } //Rank of the card, "4", "A", etc
        public char Suit { get; set; } //Suit of the card, "Diamonds(D), Spades(S)
        public string? SpecialType { get; set; } // Special Cards like "4T", "PT", etc or null for regular cards
    }
}
