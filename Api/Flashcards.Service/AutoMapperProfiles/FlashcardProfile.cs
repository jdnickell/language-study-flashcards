using AutoMapper;
using Flashcards.Domain.Table;
using Flashcards.Service.FlashcardServices.Domain;

namespace Flashcards.Service.AutoMapperProfiles
{
    public class FlashcardProfile : Profile
    {
        public FlashcardProfile()
        {
            CreateMap<Flashcard, FlashcardServiceModel>()
                .ReverseMap();
            CreateMap<Flashcard, FlashcardUpsertServiceModel>()
                .ReverseMap();
        }
    }
}
