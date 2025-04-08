using carelinkAPI.Data;
using carelinkAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carelinkAPI.Controllers{

[ApiController]
[Route("[controller]")]
public class SeedDataController : ControllerBase
{

        private readonly ClDbContext _context;

        public SeedDataController(ClDbContext context)
        {
            _context = context;
        }

        [HttpPost("init")]
        public IActionResult PopulateSeedData()
        {

            var opholdssted1 = new Opholdssted() { Name = "Andromeda" };
            var opholdssted2 = new Opholdssted() { Name = "Mælkevejen" };

            _context.Opholdssteder.AddRange(opholdssted1, opholdssted2);
            _context.SaveChanges();

            var p1 = new Person() { Opholdssted = opholdssted1 , Navn ="Hans"};
            var p2 = new Person() { Opholdssted = opholdssted1 , Navn ="Thea"};

            var p3 = new Person() { Opholdssted = opholdssted2 , Navn ="Klaus"};
            var p4 = new Person() { Opholdssted = opholdssted2 , Navn ="Jana"};
            var p5 = new Person() { Opholdssted = opholdssted2 , Navn ="Kirsten"};


            _context.Personer.AddRange(p1, p2, p3, p4, p5);
            _context.SaveChanges();

            var p1p2relation = new PersonRelation() { PersonA = p1, PersonB = p2 };
            var p3p4relation = new PersonRelation() { PersonA = p3, PersonB = p4 };
            var p4p5relation = new PersonRelation() { PersonA = p4, PersonB = p5 };


            _context.PersonRelationer.AddRange(p1p2relation, p3p4relation, p4p5relation);
            _context.SaveChanges();
            return Ok("Database was populated with seed data");
        }
    }
}
