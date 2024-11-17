using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Models;
using Pustan_Radu_Lab2_bun.Data;

namespace Pustan_Radu_Lab2_bun.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext _context;

        public EditModel(Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = await _context.Book
             .Include(b => b.Publisher)
             .Include(b => b.Author)
             .Include(b => b.BookCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Book);
            /*var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });*/
            //ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
 {
 if (id == null)
 {
 return NotFound();
 }
//se va include Author conform cu sarcina de la lab 2
 var bookToUpdate = await _context.Book
 .Include(i => i.Publisher)
 .Include(i => i.BookCategories)
 .ThenInclude(i => i.Category)
 .FirstOrDefaultAsync(s => s.ID == id);
 if (bookToUpdate == null)
 {
 return NotFound();
 }
//se va modifica AuthorID conform cu sarcina de la lab 2
 if (await TryUpdateModelAsync<Book>(
 bookToUpdate,
 "Book",
 i => i.Title, i => i.Author,
 i => i.Price, i => i.PublishingDate, i => i.PublisherID))
 {
 UpdateBookCategories(_context, selectedCategories, bookToUpdate);
 await _context.SaveChangesAsync();
 return RedirectToPage("./Index");
 }
//Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
//este editata
 UpdateBookCategories(_context, selectedCategories, bookToUpdate);
 PopulateAssignedCategoryData(_context, bookToUpdate);
 return Page();
 }
 } 
}
