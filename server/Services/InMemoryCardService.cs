using System.ComponentModel.DataAnnotations.Schema;
using CardboardArchivistAPI.Models.Collection;

namespace CardboardArchivistAPI.Services;

public class InMemoryCardService : ICardService
{
    private static List<Card> Cards { get; } = [];

    public InMemoryCardService()
    {
        Cards.AddRange([
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
        ]);
    }

    public List<Card> GetCards() => Cards;
}