using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            return Ok("api works");
        }
    }
}
//Scaffold-DbContext "Server=.\SQLExpress;Database=Flashcards;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
//Scaffold-DbContext "Server=.\SQLExpress;Database=Flashcards;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models