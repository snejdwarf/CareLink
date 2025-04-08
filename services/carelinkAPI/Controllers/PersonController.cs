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
        }

        [HttpGet("allepersoner")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersoner()
        {
            var personer = await _context.Personer.ToListAsync();
            return Ok(personer);
        }

        [HttpGet("familie")]
        public async Task<ActionResult<IEnumerable<Person>>> GetFamilie(int personid)
        {
            var person = await _context.Personer.FindAsync(personid);
            if(person == null)
            {
                return NotFound("Personen med det angivne id findes ikke");
            }

            var relationer = await _context.PersonRelationer
                .Where(pr => pr.PersonA.Id == personid || pr.PersonB.Id == personid)
                .Include(pr => pr.PersonA.Opholdssted)
                .Include(pr => pr.PersonB.Opholdssted)
                .ToListAsync();

            var familie = relationer.SelectMany(pr => new[] { pr.PersonA, pr.PersonB })
                .Distinct();


            //var familie = await _context.PersonRelationer
            //    .Where(pr => pr.PersonA.Id == personid || pr.PersonB.Id == personid)
            //    .ToListAsync()
            //    .SelectMany(pr => new[] { pr.PersonA, pr.PersonB })
            //    .Distinct()
            //    .Include(p => p.Opholdssted);

            return Ok(familie);
        }

        [HttpGet("personeropholdssted/{opholdsstedid}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonerAssociatedWithOpholdssted(int opholdsstedid)
        {
            var opholdssted = await _context.Opholdssteder.FindAsync(opholdsstedid);

            if(opholdssted == null)
            {
                return NotFound("Opholdsstedet med det angivne id findes ikke");
            }

            var personer = await _context.Personer.Where(p => p.Opholdssted.Id == opholdsstedid)
                .Include(p => p.Opholdssted.Id)
                .ToListAsync();

            if(personer ==null || !personer.Any())
            {
                return NotFound("Der findes ingen personer med tilknytning til det angivne opholdssted");
            }

            return Ok(personer);
        }

    }
}
