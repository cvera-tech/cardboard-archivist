using System.ComponentModel.DataAnnotations.Schema;
using CardboardArchivistAPI.Models.Collection;

namespace CardboardArchivistAPI.Services;

public class InMemoryCardService : ICardService
{
    private static List<Card> Cards { get; } = 
    [
        new()
        {
            UUID = "card-uuid-1",
            ReferenceUUID = "reference-uuid-1",
            DeckUUID = "deck-uuid-1"
        },
        new()
        {
            UUID = "card-uuid-2",
            ReferenceUUID = "reference-uuid-1"
        },
        new()
        {
            UUID = "card-uuid-3",
            ReferenceUUID = "reference-uuid-2",
            DeckUUID = "deck-uuid-2"
        }
    ];
    private static int uuidCounter = 4;



    public string? Create(Card card)
    {
        card.UUID = $"card-uuid-{uuidCounter++}";
        Cards.Add(card);
        return card.UUID;
    }
    
    public bool Delete(string UUID)
    {
        Card? cardToDelete = Cards.FirstOrDefault(card => card.UUID!.Equals(UUID));
        if (cardToDelete is null)
            return false;
        else
        {
            Cards.Remove(cardToDelete);
            return true;
        }
    }
    
    public Card? Get(string UUID) => Cards.FirstOrDefault(card => card.UUID!.Equals(UUID));

    public List<Card> GetAll() => Cards;

    public void Update(Card card)
    {

    }
}