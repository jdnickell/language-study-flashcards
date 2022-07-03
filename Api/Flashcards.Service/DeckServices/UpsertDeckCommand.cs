using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Domain.Table;
using Flashcards.Service.DeckServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.DeckServices
{
    public class UpsertDeckCommand : IUpsertDeckCommand
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardsContext;

        public UpsertDeckCommand(IMapper mapper, FlashcardsContext flashcardsContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }

        public async Task<int> ExecuteAsync(DeckServiceModel deckServiceModel)
        {
            if (_flashcardsContext.Decks.IgnoreAutoIncludes().Any(e => e.Name == deckServiceModel.Name))
            {
                throw new Exception($"A deck with the name: {deckServiceModel.Name} already exists.");
            }

            var deck = _mapper.Map<Deck>(deckServiceModel);

            await _flashcardsContext.Decks.AddAsync(deck);
            await _flashcardsContext.SaveChangesAsync();

            return deck.Id;
        }

        public async Task<int> ExecuteAsync(int id, DeckServiceModel deckServiceModel)
        {
            var deck = await _flashcardsContext.Decks.FirstOrDefaultAsync(x => x.Id == id);

            if (deck == null)
                throw new Exception($"Deck not found with id: {id}");

            _mapper.Map(deckServiceModel, deck);

            await _flashcardsContext.SaveChangesAsync();

            return id;
        }

        public async Task ExecuteAsync(DeckFlashCardServiceModel deckFlashCardServiceModel)
        {
            var existingDeckFlashCard = await _flashcardsContext.DeckFlashcards
                .FirstOrDefaultAsync(x => x.DeckId == deckFlashCardServiceModel.DeckId && x.FlashcardId == deckFlashCardServiceModel.FlashCardId);

            if (existingDeckFlashCard != null)
            {
                throw new Exception($"Flashcard id: {deckFlashCardServiceModel.FlashCardId} already exists in Deck id: {deckFlashCardServiceModel.DeckId}");
            }

            var deckFlashCard = _mapper.Map<DeckFlashcard>(deckFlashCardServiceModel);

            await _flashcardsContext.DeckFlashcards.AddAsync(deckFlashCard);
            await _flashcardsContext.SaveChangesAsync();
        }
    }

    public interface IUpsertDeckCommand
    {
        Task<int> ExecuteAsync(DeckServiceModel deckServiceModel);
        Task<int> ExecuteAsync(int id, DeckServiceModel deckServiceModel);
        Task ExecuteAsync(DeckFlashCardServiceModel deckFlashCardServiceModel);
    }
}
