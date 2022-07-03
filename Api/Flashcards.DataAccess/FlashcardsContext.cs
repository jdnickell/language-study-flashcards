using Flashcards.Domain.Table;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.DataAccess
{
    public partial class FlashcardsContext : DbContext
    {
        public FlashcardsContext()
        {
        }

        public FlashcardsContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Deck> Decks { get; set; } = null!;
        public virtual DbSet<DeckFlashcard> DeckFlashcards { get; set; } = null!;
        public virtual DbSet<Flashcard> Flashcards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Color)
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Deck>(entity =>
            {
                entity.ToTable("Deck");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeckFlashcard>(entity =>
            {
                entity.ToTable("Deck_Flashcard");

                entity.HasIndex(e => e.DeckId, "IX_Deck_Flashcard");

                entity.HasOne(d => d.Deck)
                    .WithMany()
                    .HasForeignKey(d => d.DeckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deck_Flashcard_Deck");

                entity.HasOne(d => d.Flashcard)
                    .WithMany()
                    .HasForeignKey(d => d.FlashcardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deck_Flashcard_Flashcard");
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.ToTable("Flashcard");

                entity.Property(e => e.Back)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Front)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Flashcards)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashcard_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
