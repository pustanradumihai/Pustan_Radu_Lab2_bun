﻿using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Models;

namespace Pustan_Radu_Lab2_bun.Data
{
    public class Pustan_Radu_Lab2_bunContext : DbContext
    {
        public Pustan_Radu_Lab2_bunContext(DbContextOptions<Pustan_Radu_Lab2_bunContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<Borrowing> Borrowing { get; set; } = default!;
    }
}
