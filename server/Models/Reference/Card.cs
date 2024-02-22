
namespace CardboardArchivistApi.Models.Reference;

public class Card
{
    public string CollectorNumber { get; set; }
    public string FoilType { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string ScryfallApiUri { get; set; }
    public Guid ScryfallId { get; set; }
    public string ScryfallUri { get; set; }
    public Set Set { get; set; }
}