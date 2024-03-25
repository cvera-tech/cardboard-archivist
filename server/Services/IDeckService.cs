using CardboardArchivistApi.Models.Collection;

namespace CardboardArchivistApi.Services;

public interface IDeckService
{
    public string? Create(Deck deck);
    public bool Delete(string id);
    public Deck? Get(string id);
    public List<Deck> GetAll();
    public void Update(Deck deck);
}