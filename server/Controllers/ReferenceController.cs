using CardboardArchivistApi.Models.Reference;
using CardboardArchivistApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardboardArchivistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReferenceController(IReferenceService referenceService) : ControllerBase
{
    private readonly IReferenceService _referenceService = referenceService;

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Card> GetCard(string id)
    {
        Card? card = _referenceService.GetCard(new Guid(id));
        if (card is null)
            return NotFound();
        return Ok(card);
    }
}