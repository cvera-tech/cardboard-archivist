using CardboardArchivistAPI.Models.Collection;

namespace CardboardArchivistAPI.Services;

public interface ICardService
{
    public List<Card> GetCards();
}