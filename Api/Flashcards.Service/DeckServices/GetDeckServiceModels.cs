using AutoMapper;
using Flashcards.DataAccess;
using Flashcards.Service.DeckServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Service.DeckServices
{
    public class GetDeckServiceModels : IGetDeckServiceModels
    {
        private readonly IMapper _mapper;
        private readonly FlashcardsContext _flashcardsContext;

        public GetDeckServiceModels(IMapper mapper, FlashcardsContext flashcardsContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _flashcardsContext = flashcardsContext ?? throw new ArgumentNullException(nameof(flashcardsContext));
        }

        public async Task<DeckServiceModel> GetAsync(int id)
        {
            var deck = await _flashcardsContext.Decks.FirstOrDefaultAsync(c => c.Id == id);

            if (deck == null)
                throw new Exception($"Deck not found with id: {id}");

            var deckServiceModel = _mapper.Map<DeckServiceModel>(deck);
            return deckServiceModel;
        }

        public async Task<List<DeckServiceModel>> GetListAsync()
        {
            var decks = await _flashcardsContext.Decks.IgnoreAutoIncludes().ToListAsync();
            var deckServiceModels = _mapper.Map<List<DeckServiceModel>>(decks);
            return deckServiceModels;
        }
    }

    public interface IGetDeckServiceModels
    {
        Task<DeckServiceModel> GetAsync(int id);
        Task<List<DeckServiceModel>> GetListAsync();
    }
}
