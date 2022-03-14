namespace Flashcards.Domain.Table
{
    public partial class Flashcard
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Front { get; set; } = null!;
        public string Back { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
