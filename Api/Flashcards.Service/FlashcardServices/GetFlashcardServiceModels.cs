using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Service.FlashcardServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.FlashcardServices
{
    public class GetFlashcardServiceModels : IGetFlashcardServiceModels
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardsContext;

        public GetFlashcardServiceModels(IMapper mapper
            , FlashcardsContext flashcardsContext)
        {
            _mapper = mapper;
            _flashcardsContext = flashcardsContext;
        }

        public async Task<FlashcardServiceModel> GetAsync(int id)
        {
            var flashcard = await _flashcardsContext.Flashcards.FirstOrDefaultAsync(c => c.Id == id);

            if (flashcard == null)
                throw new Exception($"Flashcard not found with id: {id}");

            var flashcardServiceModel = _mapper.Map<FlashcardServiceModel>(flashcard);

            return flashcardServiceModel;
        }

        public async Task<List<FlashcardServiceModel>> GetListAsync()
        {
            var flashcards = await _flashcardsContext.Flashcards.ToListAsync();
            var flashcardServiceModels = _mapper.Map<List<FlashcardServiceModel>>(flashcards);

            return flashcardServiceModels;
        }

        public async Task<List<FlashcardServiceModel>> GetListAsync(int categoryId)
        {
            var flashcards = await _flashcardsContext.Flashcards.Where(x => x.CategoryId == categoryId).ToListAsync();
            var flashcardServiceModels = _mapper.Map<List<FlashcardServiceModel>>(flashcards);

            return flashcardServiceModels;
        }
    }

    public interface IGetFlashcardServiceModels
    {
        Task<FlashcardServiceModel> GetAsync(int id);
        Task<List<FlashcardServiceModel>> GetListAsync();
        Task<List<FlashcardServiceModel>> GetListAsync(int categoryId);
    }
}
