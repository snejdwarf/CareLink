using carelinkAPI.Data;
using carelinkAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carelinkAPI.Controllers{

[ApiController]
[Route("[controller]")]
public class OpholdsstedController : ControllerBase
{

        private readonly ClDbContext _context;

        public OpholdsstedController(ClDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetOpholdssteder()
        {
            var opholdssteder = await _context.Opholdssteder.ToListAsync();
            return Ok(opholdssteder);
        }

      

    }
}
