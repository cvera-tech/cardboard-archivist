using CardboardArchivistAPI.Models.Collection;
using CardboardArchivistAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardboardArchivistAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController(ICardService cardService) : ControllerBase
{
    private readonly ICardService _cardService = cardService;

    [HttpGet]
    public ActionResult<IEnumerable<Card>> GetAll() => Ok(_cardService.GetAll());

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Card?> Get(string id)
    {
        Card? card = _cardService.Get(id);
        if (card is null)
            return NotFound();
        return Ok();
    }

    [HttpPost]
    public ActionResult<string?> Add(Card card) 
    {
        string? newCardId = _cardService.Create(card);
        if (newCardId is null)
            return BadRequest();
        string newCardUri = GetUri(newCardId);
        return Created(newCardUri, new { cardId = newCardId });
    }

    [HttpDelete]
    public bool Remove(string id) => _cardService.Delete(id);

    private string GetUri(string id) => $"{HttpContext.Request.PathBase}/card/{id}";
}