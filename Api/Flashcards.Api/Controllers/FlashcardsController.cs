﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flashcards.Api.Models;
using Flashcards.Api.ServiceModels;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly FlashcardsContext _context;

        public FlashcardsController(FlashcardsContext context)
        {
            _context = context;
        }

        // GET: api/Flashcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetFlashcards()
        {
            return await _context.Flashcards.ToListAsync();
        }

        // GET: api/Flashcards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flashcard>> GetFlashcard(int id)
        {
            var flashcard = await _context.Flashcards.FindAsync(id);

            if (flashcard == null)
            {
                return NotFound();
            }

            return flashcard;
        }

        // PUT: api/Flashcards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashcard(int id, Flashcard flashcard)
        {
            if (id != flashcard.Id)
            {
                return BadRequest();
            }

            _context.Entry(flashcard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashcardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flashcards
        [HttpPost]
        public async Task<ActionResult<Flashcard>> PostFlashcard(FlashcardServiceModel flashcardServiceModel)
        {
            var flashcard = new Flashcard
            {
                Id = flashcardServiceModel.Id,
                Back = flashcardServiceModel.Back,
                CategoryId = flashcardServiceModel.CategoryId,
                Front = flashcardServiceModel.Front,
                Title = flashcardServiceModel.Title
            };

            _context.Flashcards.Add(flashcard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlashcard", new { id = flashcard.Id }, flashcard);
        }

        // DELETE: api/Flashcards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcard(int id)
        {
            var flashcard = await _context.Flashcards.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }

            _context.Flashcards.Remove(flashcard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlashcardExists(int id)
        {
            return _context.Flashcards.Any(e => e.Id == id);
        }
    }
}
