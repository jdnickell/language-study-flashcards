namespace Flashcards.Service.FlashcardServices.Domain
{
    public class FlashcardUpsertServiceModel
    {
        public string Title { get; set; } = string.Empty;
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
