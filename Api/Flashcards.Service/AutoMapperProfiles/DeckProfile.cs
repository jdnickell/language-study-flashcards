using AutoMapper;
using Flashcards.Domain.Table;
using Flashcards.Service.DeckServices.Domain;

namespace Flashcards.Service.AutoMapperProfiles
{
    public class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, DeckServiceModel>()
                .ReverseMap();
        }
    }
}
