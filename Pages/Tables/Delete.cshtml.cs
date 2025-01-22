using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Proiect.Data;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Pages.Tables
{
    public class DeleteModel : PageModel
    {
        private readonly Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext _context;

        public DeleteModel(Pop_Claudia_Proiect.Data.Pop_Claudia_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table Table { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FirstOrDefaultAsync(m => m.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            else
            {
                Table = table;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table != null)
            {
                Table = table;
                _context.Table.Remove(Table);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
