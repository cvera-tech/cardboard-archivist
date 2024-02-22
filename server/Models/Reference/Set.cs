namespace CardboardArchivistApi.Models.Reference;

public class Set
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required Guid ScryfallId { get; set; }
    public required string ScryfallApiUri { get; set; }
    public required string ScryfallUri { get; set; }
}