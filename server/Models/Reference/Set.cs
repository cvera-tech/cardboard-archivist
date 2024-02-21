namespace CardboardArchivistAPI.Models.Reference;

public class Set
{
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid ScryfallId { get; set; }
    public string ScryfallApiUri { get; set; }
    public string ScryfallUri { get; set; }
}