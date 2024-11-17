using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pustan_Radu_Lab2_bun.Models;
using Pustan_Radu_Lab2_bun.Data;

namespace Pustan_Radu_Lab2_bun.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext _context;

        public CreateModel(Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext context)
        {          
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "LastName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
