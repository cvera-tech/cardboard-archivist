using CardboardArchivistApi.Models.Collection;

namespace CardboardArchivistApi.Services;

public class InMemoryDeckService : IDeckService
{
    private static List<Deck> Decks { get; } = 
    [
        new()
        {
            Cards = [],
            Id = "deck-uuid-1",
            Name = "In-Memory Deck 1"
        }
    ];
    private static int uuidCounter = 2;

    public string? Create(Deck deck)
    {
        deck.Id = $"deck-uuid-{uuidCounter++}";
        Decks.Add(deck);
        return deck.Id;
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Deck? Get(string id)
    {
        return Decks.FirstOrDefault(deck => deck.Id!.Equals(id));
    }

    public List<Deck> GetAll()
    {
        return Decks;
    }

    public void Update(Deck deck)
    {
        throw new NotImplementedException();
    }
}