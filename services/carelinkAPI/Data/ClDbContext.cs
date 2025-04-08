using carelinkAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carelinkAPI.Data
{
    public class ClDbContext : DbContext
    {
        public ClDbContext(DbContextOptions<ClDbContext> options) : base(options) { }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Opholdssted> Opholdssteder { get; set; }
        public DbSet<PersonRelation> PersonRelationer { get; set; }

    }
}
