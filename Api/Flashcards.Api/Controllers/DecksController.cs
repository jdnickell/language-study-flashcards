//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Flashcards.Api.Models;

//namespace Flashcards.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DecksController : ControllerBase
//    {
//        private readonly FlashcardsContext _context;

//        public DecksController(FlashcardsContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Decks
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Deck>>> GetDecks()
//        {
//            return await _context.Decks.ToListAsync();
//        }

//        // GET: api/Decks/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Deck>> GetDeck(int id)
//        {
//            var deck = await _context.Decks.FindAsync(id);

//            if (deck == null)
//            {
//                return NotFound();
//            }

//            return deck;
//        }

//        // PUT: api/Decks/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutDeck(int id, Deck deck)
//        {
//            if (id != deck.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(deck).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!DeckExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Decks
//        [HttpPost]
//        public async Task<ActionResult<Deck>> PostDeck(Deck deck)
//        {
//            _context.Decks.Add(deck);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetDeck", new { id = deck.Id }, deck);
//        }

//        // DELETE: api/Decks/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteDeck(int id)
//        {
//            var deck = await _context.Decks.FindAsync(id);
//            if (deck == null)
//            {
//                return NotFound();
//            }

//            _context.Decks.Remove(deck);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool DeckExists(int id)
//        {
//            return _context.Decks.Any(e => e.Id == id);
//        }
//    }
//}
