using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Domain.Table;
using Flashcards.Service.FlashcardServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.FlashcardServices
{
    public class UpsertFlashcardCommand : IUpsertFlashcardCommand
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardContext;

        public UpsertFlashcardCommand(IMapper mapper, FlashcardsContext flashcardContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _flashcardContext = flashcardContext ?? throw new ArgumentNullException(nameof(flashcardContext));
        }

        public async Task<int> ExecuteAsync(FlashcardUpsertServiceModel flashcardUpsertServiceModel)
        {
            var flashcard = _mapper.Map<Flashcard>(flashcardUpsertServiceModel);

            await _flashcardContext.Flashcards.AddAsync(flashcard);
            await _flashcardContext.SaveChangesAsync();

            return flashcard.Id;
        }

        public async Task<int> ExecuteAsync(int id, FlashcardUpsertServiceModel flashcardUpsertServiceModel)
        {
            var flashcard = await _flashcardContext.Flashcards.FirstOrDefaultAsync(x => x.Id == id);

            if (flashcard == null)
                throw new Exception($"Flashcard not found with id: {id}");

            _mapper.Map(flashcardUpsertServiceModel, flashcard);

            await _flashcardContext.SaveChangesAsync();

            return id;
        }
    }

    public interface IUpsertFlashcardCommand
    {
        Task<int> ExecuteAsync(FlashcardUpsertServiceModel flashcardUpsertServiceModel);
        Task<int> ExecuteAsync(int id, FlashcardUpsertServiceModel flashcardUpsertServiceModel);
    }
}
