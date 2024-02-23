using CardboardArchivistApi.Models.Reference;

namespace CardboardArchivistApi.Services;

public interface IReferenceService
{
    public Card? GetCard(Guid id);
    public Set? GetSet(Guid id);
}