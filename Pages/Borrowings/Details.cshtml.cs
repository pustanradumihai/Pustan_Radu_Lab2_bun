using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Data;
using Pustan_Radu_Lab2_bun.Models;

namespace Pustan_Radu_Lab2_bun.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext _context;

        public DetailsModel(Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

          
            var borrowing = await _context.Borrowing
                .Include(b => b.Book)  
                .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }

             Borrowing = borrowing;

            return Page();
        }
    }
}
