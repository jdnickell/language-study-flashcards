using Microsoft.AspNetCore.Mvc;
using Flashcards.Service.FlashcardServices.Domain;
using Flashcards.Service.FlashcardServices;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IGetFlashcardServiceModels _getFlashcardServiceModels;

        public FlashcardsController(IGetFlashcardServiceModels getFlashcardServiceModels)
        {
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
    }
}
