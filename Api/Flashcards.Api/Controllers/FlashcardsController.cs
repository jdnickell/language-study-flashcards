using Microsoft.AspNetCore.Mvc;
using Flashcards.Service.FlashcardServices.Domain;
using Flashcards.Service.FlashcardServices;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IUpsertFlashcardCommand _upsertFlashcardCommand;
        private readonly IDeleteFlashcardCommand _deleteFlashcardCommand;
        private readonly IGetFlashcardServiceModels _getFlashcardServiceModels;

        public FlashcardsController(IUpsertFlashcardCommand upsertFlashcardCommand
            , IDeleteFlashcardCommand deleteFlashcardCommand
            , IGetFlashcardServiceModels getFlashcardServiceModels)
        {
            _upsertFlashcardCommand = upsertFlashcardCommand;
            _deleteFlashcardCommand = deleteFlashcardCommand;
            _getFlashcardServiceModels = getFlashcardServiceModels;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlashcardServiceModel>>> GetFlashcards()
        {
            var flashCards = await _getFlashcardServiceModels.GetListAsync();
            return Ok(flashCards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlashcardServiceModel>> GetFlashcard(int id)
        {
            var flashCard = await _getFlashcardServiceModels.GetAsync(id);
            return Ok(flashCard);
        }

        [HttpGet]
        [Route("GetByCategoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<FlashcardServiceModel>>> GetFlashcardsByCategoryId(int categoryId)
        {
            var flashCard = await _getFlashcardServiceModels.GetListByCategoryIdAsync(categoryId);
            return Ok(flashCard);
        }

        [HttpPost]
        public async Task<ActionResult<FlashcardServiceModel>> PostDeck(FlashcardUpsertServiceModel flashcardUpsertServiceModel)
        {
            var flashCardId = await _upsertFlashcardCommand.ExecuteAsync(flashcardUpsertServiceModel);

            var flashcardServiceModel = await _getFlashcardServiceModels.GetAsync(flashCardId);

            return Ok(flashcardServiceModel);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _deleteFlashcardCommand.ExecuteAsync(id);
            return NoContent();
        }
    }
}
