using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pustan_Radu_Lab2_bun.Data;
using Pustan_Radu_Lab2_bun.Models;
using Pustan_Radu_Lab2_bun.Models.ViewModels;

namespace Pustan_Radu_Lab2_bun.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext _context;

        public IndexModel(Pustan_Radu_Lab2_bun.Data.Pustan_Radu_Lab2_bunContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
