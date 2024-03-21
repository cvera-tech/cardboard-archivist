using CardboardArchivistApi.Models.Collection;

namespace CardboardArchivistApi.Services;

public class InMemoryCardService : ICardService
{
    private static List<Card> Cards { get; } = 
    [
        new()
        {
            Id = "card-uuid-1",
            ReferenceId = new Guid("00000000-0000-0000-0001-000000000001"),
            DeckId = new Guid("00000000-0000-0000-0002-000000000001")
        },
        new()
        {
            Id = "card-uuid-2",
            ReferenceId = new Guid("00000000-0000-0000-0001-000000000002")
        },
        new()
        {
            Id = "card-uuid-3",
            ReferenceId = new Guid("00000000-0000-0000-0001-000000000003"),
            DeckId = new Guid("00000000-0000-0000-0002-000000000001")
        }
    ];
    private static int uuidCounter = 4;

    public string? Create(Card card)
    {
        card.Id = $"card-uuid-{uuidCounter++}";
        Cards.Add(card);
        return card.Id;
    }
    
    public bool Delete(string UUID)
    {
        Card? cardToDelete = Get(UUID);
        if (cardToDelete is null)
            return false;
        Cards.Remove(cardToDelete);
        return true;
    }
    
    public Card? Get(string UUID) => Cards.FirstOrDefault(card => card.Id!.Equals(UUID));

    private int GetIndex(string UUID) => Cards.FindIndex(card => card.Id!.Equals(UUID));

    public List<Card> GetAll() => Cards;

    public void Update(Card card)
    {
        if (card.Id is null)
            // TODO: Perhaps throw and handle an exception here?
            return;
        int cardToUpdateIndex = GetIndex(card.Id!);
        if (cardToUpdateIndex < 0)
            return;
        Cards[cardToUpdateIndex] = card;
    }
}