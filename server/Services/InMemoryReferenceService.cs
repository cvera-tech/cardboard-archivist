using CardboardArchivistApi.Models.Reference;

namespace CardboardArchivistApi.Services;

public class InMemoryReferenceService : IReferenceService
{
    private static List<Card> Cards { get; } = 
    [
        new()
        {
            CollectorNumber = "446",
            FoilType = "",
            Language = "en",
            Name = "Vivid Meadow",
            // ScryfallApiUri = "https://api.scryfall.com/cards/625a42b4-d88c-48e0-96b1-77388ca48810",
            ScryfallId = new Guid("625a42b4-d88c-48e0-96b1-77388ca48810"),
            SetCode = "NCC"
        }
    ];

    // private static List<Set> Sets { get; } =
    // {
    //     new()
    //     {
    //         Code = "NCC",
    //         Name = "New Capenna Commander",
    //         ScryfallId = new Guid("c51de34b-d4d6-4179-a432-573744ded119"),
    //         ScryfallApiUri = "https://api.scryfall.com/sets/c51de34b-d4d6-4179-a432-573744ded119"
    //     }
    // }

    public Card? GetCard(Guid id)
    {
        return Cards.FirstOrDefault(card => card.ScryfallId == id);
    }

    public Card? GetCard(string name, string setCode, string collectorNumber)
    {
        return Cards.FirstOrDefault(card =>
            card.Name == name &&
            card.SetCode == setCode &&
            card.CollectorNumber == collectorNumber);
    }

    public Set? GetSet(Guid id)
    {
        // return Sets.FirstOrDefault(set => set.Id.Equals(id));
        throw new NotImplementedException();
    }
}