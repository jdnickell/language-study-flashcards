using Flashcards.DataAccess;
using Flashcards.Service.DeckServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.DeckServices
{
    public class DeleteDeckCommand : IDeleteDeckCommand
    {
        private readonly FlashcardsContext _flashcardsContext;

        public DeleteDeckCommand(FlashcardsContext flashcardsContext)
        {
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }
        
        /// <summary>
        /// Deletes an entire Deck and all Deck/Flashcard associations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(int deckId)
        {
            var deckFlashcards = await _flashcardsContext.DeckFlashcards.Where(x => x.DeckId == deckId).ToListAsync();
            if (deckFlashcards.Any())
            {
                _flashcardsContext.DeckFlashcards.RemoveRange(deckFlashcards);
                await _flashcardsContext.SaveChangesAsync();
            }

            var deck = await _flashcardsContext.Decks.Where(x => x.Id == deckId).FirstOrDefaultAsync();
            if(deck == null)
            { 
                throw new Exception($"Deck with id {deckId} not found.");
            }

            _flashcardsContext.Remove(deck);
            await _flashcardsContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a single Deck/Flashcard association
        /// </summary>
        /// <param name="deckId"></param>
        /// <param name="flashCardId"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(DeckFlashCardServiceModel deckFlashCardServiceModel)
        {
            var deckFlashCard = await _flashcardsContext.DeckFlashcards
                .FirstOrDefaultAsync(x => x.DeckId == deckFlashCardServiceModel.DeckId && x.FlashcardId == deckFlashCardServiceModel.FlashCardId);

            if (deckFlashCard == null)
            {
                throw new Exception($"Deck Flashcard with Deck Id {deckFlashCardServiceModel.DeckId} and Flashcard Id {deckFlashCardServiceModel.FlashCardId} not found.");
            }

            _flashcardsContext.Remove(deckFlashCard);
            await _flashcardsContext.SaveChangesAsync();
        }
    }

    public interface IDeleteDeckCommand
    {
        Task ExecuteAsync(int id);
        Task ExecuteAsync(DeckFlashCardServiceModel deckFlashCardServiceModel);
    }
}
