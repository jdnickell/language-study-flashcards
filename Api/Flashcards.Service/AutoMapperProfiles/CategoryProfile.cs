using AutoMapper;
using Flashcards.Domain.Table;
using Flashcards.Service.CategoryServices.Domain;

namespace Flashcards.Service.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryServiceModel>()
                .ReverseMap();
            CreateMap<Category, CategoryUpsertServiceModel>()
                .ReverseMap();
        }
    }
}
