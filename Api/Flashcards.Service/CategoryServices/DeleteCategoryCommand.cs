using Flashcards.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.CategoryServices
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly FlashcardsContext _flashcardsContext;

        public DeleteCategoryCommand(FlashcardsContext flashcardsContext)
        {
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }

        public async Task ExecuteAsync(int id)
        {
            var category = await _flashcardsContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                throw new Exception($"Category with id {id} not found.");

            //TODO: Category may already be assigned to flashcards and those flashcards may already exist in other decks

            _flashcardsContext.Categories.Remove(category);
            await _flashcardsContext.SaveChangesAsync();
        }
    }

    public interface IDeleteCategoryCommand
    {
        Task ExecuteAsync(int id);
    }
}
