
namespace CardboardArchivistApi.Models.Reference;

public class Card
{
    public required string CollectorNumber { get; set; }
    public required string FoilType { get; set; }
    public required string Language { get; set; }
    public required string Name { get; set; }
    //public required string ScryfallApiUri { get; set; }
    public required Guid ScryfallId { get; set; }
    //public required string ScryfallUri { get; set; }
    public required string SetCode { get; set; }
}