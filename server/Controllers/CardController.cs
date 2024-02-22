using CardboardArchivistApi.Models.Collection;
using CardboardArchivistApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardboardArchivistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController(ICardService cardService) : ControllerBase
{
    private readonly ICardService _cardService = cardService;

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
    [Route("{id}")]
    public ActionResult Delete(string id)
    {
        if (_cardService.Get(id) is null)
            return NotFound();
        _cardService.Delete(id);
        return NoContent();
    } 

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Card?> Get(string id)
    {
        Card? card = _cardService.Get(id);
        if (card is null)
            return NotFound();
        return Ok();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Card>> GetAll() => Ok(_cardService.GetAll());

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(string id, Card card)
    {
        if (_cardService.Get(id) is null)
            return NotFound(new { msg = "Invalid ID."});
        // TODO: Implement DeckId validation
        // if (_deckService.Get(card.DeckId) is null)
        //  return BadRequest(new { msg = "Invalid Deck ID" });
        _cardService.Update(new Card() {
            UUID = id,
            ReferenceUUID = card.ReferenceUUID,
            DeckUUID = card.DeckUUID
        });
        return Ok();
    }

    private string GetUri(string id) => $"{HttpContext.Request.PathBase}/card/{id}";
}