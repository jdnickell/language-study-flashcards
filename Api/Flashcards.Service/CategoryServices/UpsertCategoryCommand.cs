using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Domain.Table;
using Flashcards.Service.CategoryServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.CategoryServices
{
    public class UpsertCategoryCommand : IUpsertCategoryCommand
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardContext;

        public UpsertCategoryCommand(IMapper mapper, FlashcardsContext flashcardContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _flashcardContext = flashcardContext ?? throw new ArgumentNullException(nameof(flashcardContext));
        }

        public async Task<int> ExecuteAsync(CategoryUpsertServiceModel categoryUpsertServiceModel)
        {
            if (_flashcardContext.Categories.Any(e => e.Name == categoryUpsertServiceModel.Name))
            {
                throw new Exception($"A category with the name: {categoryUpsertServiceModel.Name} already exists.");
            }

            var category = _mapper.Map<Category>(categoryUpsertServiceModel);

            await _flashcardContext.Categories.AddAsync(category);
            await _flashcardContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<int> ExecuteAsync(int id, CategoryUpsertServiceModel categoryUpsertServiceModel)
        {
            var category = await _flashcardContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                throw new Exception($"Category not found with id: {id}");

            _mapper.Map(categoryUpsertServiceModel, category);

            await _flashcardContext.SaveChangesAsync();

            return id;
        }
    }

    public interface IUpsertCategoryCommand
    {
        Task<int> ExecuteAsync(CategoryUpsertServiceModel categoryUpsertServiceModel);
        Task<int> ExecuteAsync(int id, CategoryUpsertServiceModel categoryUpsertServiceModel);
    }
}
