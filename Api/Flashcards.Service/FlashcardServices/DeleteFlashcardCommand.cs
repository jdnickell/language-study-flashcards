using Flashcards.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.FlashcardServices
{
    public class DeleteFlashcardCommand : IDeleteFlashcardCommand
    {
        private readonly FlashcardsContext _flashcardsContext;

        public DeleteFlashcardCommand(FlashcardsContext flashcardsContext)
        {
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }

        public async Task ExecuteAsync(int id)
        {
            //TODO: handle validation for when flashcard is assigned to a deck
            var flashCard = await _flashcardsContext.Flashcards.FirstOrDefaultAsync(x => x.Id == id);
            if (flashCard == null)
            {
                throw new Exception($"Flashcard with id: {id} not found.");
            } 

            _flashcardsContext.Remove(flashCard);
            await _flashcardsContext.SaveChangesAsync();
        }
    }

    public interface IDeleteFlashcardCommand
    {
        Task ExecuteAsync(int id);
    }
}
