using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Proiect.Data;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Pages.Menus
{
    public class IndexModel : PageModel
    {
        private readonly Pop_Claudia_ProiectContext _context;

        public IndexModel(Pop_Claudia_ProiectContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
          
            var menuQuery = _context.Menu.Include(m => m.Restaurant).AsQueryable();

            
            if (!string.IsNullOrEmpty(SearchString))
            {
                menuQuery = menuQuery.Where(m => m.Name.Contains(SearchString));
            }
            Menu = await menuQuery.ToListAsync();
        }
    }
}