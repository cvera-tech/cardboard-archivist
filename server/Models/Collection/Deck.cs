namespace CardboardArchivistApi.Models.Collection;

public class Deck
{
    public required List<Card> Cards { get; set; }
    public string? Id { get; set; }
    public required string Name { get; set; }
}