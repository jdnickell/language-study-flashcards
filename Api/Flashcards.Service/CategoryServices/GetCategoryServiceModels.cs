using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Service.CategoryServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.CategoryServices
{
    public class GetCategoryServiceModels : IGetCategoryServiceModels
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardsContext;

        public GetCategoryServiceModels(IMapper mapper, FlashcardsContext flashcardsContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }

        public async Task<CategoryServiceModel> GetAsync(int id)
        {
            var category = await _flashcardsContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                throw new Exception($"Category not found with id: {id}");

            var categoryServiceModel = _mapper.Map<CategoryServiceModel>(category);
            return categoryServiceModel;
        }

        public async Task<List<CategoryServiceModel>> GetListAsync()
        {
            var categories = await _flashcardsContext.Categories.ToListAsync();
            var categoryServiceModels = _mapper.Map<List<CategoryServiceModel>>(categories);
            return categoryServiceModels;
        }
    }

    public interface IGetCategoryServiceModels
    {
        Task<CategoryServiceModel> GetAsync(int id);
        Task<List<CategoryServiceModel>> GetListAsync();
    }
}
