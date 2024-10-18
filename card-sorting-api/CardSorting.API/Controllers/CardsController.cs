using Microsoft.AspNetCore.Mvc;
using CardSorting.API.Interfaces;
using CardSorting.API.Models;

namespace CardSorting.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardSorter _cardSorter;
        private readonly ICardValidationService _cardValidator;

        public CardsController(ICardSorter cardSorter, ICardValidationService cardValidator)
        {
            _cardSorter = cardSorter;
            _cardValidator = cardValidator;
        }

        [HttpPost("sort")]
        public ActionResult<List<string>> SortCards([FromBody] List<Card> cards)
        {
            if (!_cardValidator.ValidateCards(cards)) {
                return BadRequest("Invalid card input.");
            }
            var sortedCards = _cardSorter.SortCards(cards);
            return Ok(sortedCards);
        }
    }
}
