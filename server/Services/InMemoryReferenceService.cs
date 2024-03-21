using System.Reflection;
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
        List<(string, string)> searchOptions = [];
        
        foreach(PropertyInfo propertyInfo in searchCards.GetType().GetProperties())
        {
            var propertyValue = propertyInfo.GetValue(searchCards);
            if (propertyValue is not null)
            {
                (string, string) searchOption = (propertyInfo.Name, propertyValue.ToString()!);
                Console.WriteLine(searchOption);
                searchOptions.Add(searchOption);
            }
        }
        if (searchOptions.Count == 0)
            return Cards;
        return Cards.Where(card => 
        {
            bool match = true;
            // if (!String.IsNullOrWhiteSpace(searchCards.Name))
            //     match = match && card.Name == searchCards.Name;
            // if (!String.IsNullOrWhiteSpace(searchCards.SetCode))
            //     match = match && card.SetCode == searchCards.SetCode;
            // if (!String.IsNullOrWhiteSpace(searchCards.CollectorNumber))
            //     match = card.CollectorNumber == searchCards.CollectorNumber;
            foreach((string, string) searchOption in searchOptions)
            {
                string? cardValue = card.GetType().GetProperty(searchOption.Item1)?.GetValue(card)?.ToString();
                Console.WriteLine(cardValue);
                if (cardValue is not null)
                    match = match && cardValue == searchOption.Item2;
            }
            return match;
            
        }).ToList();
    }
}