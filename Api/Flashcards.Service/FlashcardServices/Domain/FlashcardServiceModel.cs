namespace Flashcards.Service.FlashcardServices.Domain
{
    public class FlashcardServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
