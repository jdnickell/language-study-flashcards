using Flashcards.Service.FlashcardServices.Domain;

namespace Flashcards.Service.CategoryServices.Domain
{
    public class CategoryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public List<FlashcardServiceModel> Flashcards { get; set; } = new List<FlashcardServiceModel>();
    }
}
