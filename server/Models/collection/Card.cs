namespace CardboardArchivistAPI.Models.Collection;

public class Card
{
    public required string UUID { get; set; }

    // The UUID of the card in the reference database. This is where we get all the card's info such as the name, rules text, set info, etc.
    public required string ReferenceUUID { get; set; }

    // The Deck to which this card belongs. Each card can only belong to one deck. If null, the card is in the general collection.
    public string? DeckUUID { get; set; }

    // TODO: Add support for card condition (Mint, Near Mint, Excellent, Good, Damaged, etc.)
}