namespace Flashcards.Domain.Table
{
    public partial class DeckFlashcard
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int FlashcardId { get; set; }

        public virtual Deck Deck { get; set; } = null!;
        public virtual Flashcard Flashcard { get; set; } = null!;
    }
}
