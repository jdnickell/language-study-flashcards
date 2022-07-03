using AutoMapper;
using Flashcards.Domain.Table;
using Flashcards.Service.DeckServices.Domain;

namespace Flashcards.Service.AutoMapperProfiles
{
    public class DeckFlashCardProfile : Profile
    {
        public DeckFlashCardProfile()
        {
            CreateMap<DeckFlashcard, DeckFlashCardServiceModel>()
                .ReverseMap();
        }
    }
}
