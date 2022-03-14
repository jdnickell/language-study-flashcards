namespace Flashcards.Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Flashcards = new HashSet<Flashcard>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; }
    }
}
