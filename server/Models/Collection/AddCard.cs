namespace CardboardArchivistApi.Models.Collection;

public class AddCard
{
    public required string ReferenceId { get; set; }
    public string? DeckId { get; set; }
}