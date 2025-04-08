using carelinkAPI.Data;
using carelinkAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carelinkAPI.Controllers{

[ApiController]
[Route("[controller]")]
public class CleanupController : ControllerBase
{

        private readonly ClDbContext _context;

        public CleanupController(ClDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> ClearDatabase(Person person)
        {
            _context.RemoveRange(_context.Personer);
            _context.RemoveRange(_context.PersonRelationer);
            _context.RemoveRange(_context.Opholdssteder);

            await _context.SaveChangesAsync();
            return Ok("Database cleared");
        }
    }
}
