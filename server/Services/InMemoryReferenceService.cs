using CardboardArchivistApi.Models.Reference;

namespace CardboardArchivistApi.Services;

public class InMemoryReferenceService : IReferenceService
{
    private static List<Card> Cards { get; } = 
    [
        new()
        {
            CollectorNumber = "446",
            FoilType = "nonfoil",
            Id = new Guid("b2837ab2-ddf2-4503-a73b-daf9fe156614"),
            Language = "en",
            Name = "Vivid Meadow",
            ScryfallId = new Guid("625a42b4-d88c-48e0-96b1-77388ca48810"),
            SetCode = "NCC"
        },
        new()
        {
            CollectorNumber = "17",
            FoilType = "foil",
            Id = new Guid("3e29a77b-f658-4268-8e5e-dbd432edc475"),
            Language = "en",
            Name = "Healing Hands",
            ScryfallId = new Guid("9a26559c-0ac5-42a7-b6ac-b39938c31026"),
            SetCode = "ORI"
        },
        new()
        {
            CollectorNumber = "17",
            FoilType = "nonfoil",
            Id = new Guid("d0397b43-1f99-4c4c-9d8d-a3cc775f19ee"),
            Language = "en",
            Name = "Healing Hands",
            ScryfallId = new Guid("9a26559c-0ac5-42a7-b6ac-b39938c31026"),
            SetCode = "ORI"
        }
    ];

    public Card? GetCard(Guid id)
    {
        return Cards.FirstOrDefault(card => card.Id == id);
    }

    public Set? GetSet(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Card> SearchCards(SearchCards searchCards)
    {
        return Cards.Where(card => 
        {
            bool nameMatch = !String.IsNullOrWhiteSpace(searchCards.Name) && card.Name == searchCards.Name;
            bool setCodeMatch = !String.IsNullOrWhiteSpace(searchCards.SetCode) && card.SetCode == searchCards.SetCode;
            bool collectorNumberMatch = !String.IsNullOrWhiteSpace(searchCards.CollectorNumber) && card.CollectorNumber == searchCards.CollectorNumber;
            return nameMatch && setCodeMatch && collectorNumberMatch;
            
        }).ToList();
    }
}