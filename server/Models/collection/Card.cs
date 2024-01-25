namespace CardboardArchivistAPI.Models.Collection;

public class Card
{
    public required string UUID { get; set; }
    public required string ReferenceUUID { get; set; }
    public string? DeckUUID { get; set; }
}