using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Models;

namespace Pustan_Radu_Lab2_bun.Data
{
    public class LibraryIdentityContext : IdentityDbContext<IdentityUser>
    {
        public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
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
