using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Proiect.Data;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Pages.Tables
{
    public class CreateModel : PageModel
    {
        private readonly Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext _context;

        public CreateModel(Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["RestaurantId"] = new SelectList(await _context.Restaurant.ToListAsync(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Table.Add(Table);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
