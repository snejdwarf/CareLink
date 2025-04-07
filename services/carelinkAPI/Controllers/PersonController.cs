using carelinkAPI.Data;
using carelinkAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carelinkAPI.Controllers{

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

        private readonly ClDbContext _context;

        public PersonController(ClDbContext context)
        {
            _context = context;
            var p = new Person() { id = 123 };
            _context.Personer.Add(p);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
        {
            var p = new Person() { id = 123 };
            return Ok(p);
            return await _context.Personer.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostUser(Person person)
        {
            _context.Personer.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = person.id }, person);
        }
    }
}
