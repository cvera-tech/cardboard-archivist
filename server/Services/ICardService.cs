using CardboardArchivistApi.Models.Collection;

namespace CardboardArchivistApi.Services;

public interface ICardService
{
    public string? Create(Card card);
    public bool Delete(string UUID);
    public Card? Get(string UUID);
    public List<Card> GetAll();
    public void Update(Card card);
}