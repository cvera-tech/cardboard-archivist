using CardboardArchivistApi.Models.Collection;
using CardboardArchivistApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardboardArchivistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController(IDeckService deckService) : ControllerBase
{
    private IDeckService _deckService = deckService;
    
    [HttpPost]
    public ActionResult<string?> Add(AddDeck addDeck)
    {
        Deck newDeck = new()
        {
            Cards = [],
            Name = addDeck.Name,
        };

        string? newDeckId = _deckService.Create(newDeck);
        if (newDeckId is null)
            return BadRequest();
        string newCardUri = GetUri(newDeckId);
        return Created(newCardUri, new { cardId = newDeckId });
    }

    [HttpGet]
    [Route("id")]
    public ActionResult<Deck?> Get(string id)
    {
        Deck? deck = _deckService.Get(id);
        if (deck is null)
            return NotFound();
        return Ok(deck);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Deck>> GetAll() => Ok(_deckService.GetAll());

    private string GetUri(string id) => $"{HttpContext.Request.PathBase}/deck/{id}";
}