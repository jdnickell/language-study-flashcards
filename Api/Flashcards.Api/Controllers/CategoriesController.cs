using Flashcards.Service.CategoryServices;
using Flashcards.Service.CategoryServices.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUpsertCategoryCommand _upsertCategoryCommand;
        private readonly IDeleteCategoryCommand _deleteCategoryCommand;
        private readonly IGetCategoryServiceModels _getCategoryServiceModels;

        public CategoriesController(IUpsertCategoryCommand upsertCategoryCommand
            , IDeleteCategoryCommand deleteCategoryCommand
            , IGetCategoryServiceModels getCategoryServiceModels)
        {
            _upsertCategoryCommand = upsertCategoryCommand ?? throw new ArgumentNullException(nameof(upsertCategoryCommand));
            _deleteCategoryCommand = deleteCategoryCommand ?? throw new ArgumentNullException(nameof(deleteCategoryCommand));
            _getCategoryServiceModels = getCategoryServiceModels ?? throw new ArgumentNullException(nameof(getCategoryServiceModels));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryServiceModel>> GetCategory(int id)
        {
            var categoryServiceModel = await _getCategoryServiceModels.GetAsync(id);
            return Ok(categoryServiceModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryServiceModel>>> GetCategories()
        {
            var categoryServiceModels = await _getCategoryServiceModels.GetListAsync();
            return Ok(categoryServiceModels);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryServiceModel>> PutCategory(int id, CategoryUpsertServiceModel categoryUpsertServiceModel)
        {
            await _upsertCategoryCommand.ExecuteAsync(id, categoryUpsertServiceModel);
            var categoryServiceModel = await _getCategoryServiceModels.GetAsync(id);

            return Ok(categoryServiceModel);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryServiceModel>> PostCategory(CategoryUpsertServiceModel categoryUpsertServiceModel)
        {
            var categoryId = await _upsertCategoryCommand.ExecuteAsync(categoryUpsertServiceModel);
            var categoryServiceModel = await _getCategoryServiceModels.GetAsync(categoryId);

            return Ok(categoryServiceModel);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _deleteCategoryCommand.ExecuteAsync(id);
            return NoContent();
        }
    }
}
