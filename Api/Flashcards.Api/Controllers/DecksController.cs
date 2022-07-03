using Flashcards.Service.DeckServices;
using Flashcards.Service.DeckServices.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly IDeleteDeckCommand _deleteDeckCommand;
        private readonly IUpsertDeckCommand _upsertDeckCommand;
        private readonly IGetDeckServiceModels _getDeckServiceModels;

        public DecksController(IDeleteDeckCommand deleteDeckCommand
            , IUpsertDeckCommand upsertDeckCommand
            , IGetDeckServiceModels getDeckServiceModels)
        {
            _deleteDeckCommand = deleteDeckCommand ?? throw new ArgumentNullException(nameof(deleteDeckCommand));
            _upsertDeckCommand = upsertDeckCommand ?? throw new ArgumentNullException(nameof(upsertDeckCommand));
            _getDeckServiceModels = getDeckServiceModels ?? throw new ArgumentNullException(nameof(getDeckServiceModels));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeckServiceModel>>> GetDecks()
        {
            var deckServiceModels = await _getDeckServiceModels.GetListAsync();
            return Ok(deckServiceModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeckServiceModel>> GetDeck(int id)
        {
            var deck = await _getDeckServiceModels.GetAsync(id);
            return Ok(deck);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(int id, DeckServiceModel deckServiceModel)
        {
            await _upsertDeckCommand.ExecuteAsync(id, deckServiceModel);

            var updatedDeckServiceModel = await _getDeckServiceModels.GetAsync(id);

            return Ok(updatedDeckServiceModel);
        }

        [HttpPost]
        public async Task<ActionResult<DeckServiceModel>> PostDeck(DeckServiceModel deckServiceModel)
        {
            var deckId = await _upsertDeckCommand.ExecuteAsync(deckServiceModel);

            var createdDeckServiceModel = await _getDeckServiceModels.GetAsync(deckId);

            return Ok(createdDeckServiceModel);
        }

        [HttpPost("DeckFlashCard")]
        public async Task<ActionResult<DeckServiceModel>> PostDeck(DeckFlashCardServiceModel deckFlashCardServiceModel)
        {
            await _upsertDeckCommand.ExecuteAsync(deckFlashCardServiceModel);
            return Ok();
        }

        [HttpDelete("DeckFlashCard")]
        public async Task<IActionResult> DeleteDeck(DeckFlashCardServiceModel deckFlashCardServiceModel)
        {
            await _deleteDeckCommand.ExecuteAsync(deckFlashCardServiceModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            await _deleteDeckCommand.ExecuteAsync(id);
            return Ok();
        }
    }
}
