using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Models;

namespace Pustan_Radu_Lab2_bun.Data
{
    public class Pustan_Radu_Lab2_bunContext : DbContext
    {
        public Pustan_Radu_Lab2_bunContext (DbContextOptions<Pustan_Radu_Lab2_bunContext> options)
            : base(options)
        {
        }

        public DbSet<Pustan_Radu_Lab2_bun.Models.Book> Book { get; set; } = default!;
        public DbSet<Pustan_Radu_Lab2_bun.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Pustan_Radu_Lab2_bun.Models.Author> Authors { get; set; } = default!;
    }
}
