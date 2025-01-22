using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_Claudia_Proiect.Data;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Pages.Menus
{
    public class CreateModel : PageModel
    {
        private readonly Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext _context;

        public CreateModel(Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Menu.Add(Menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
