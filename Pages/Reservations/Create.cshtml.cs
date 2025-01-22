using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Proiect.Data;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Pages.Reservations
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
            var customers = _context.Customer.ToList();
            var tables = _context.Table.ToList();


            Debug.WriteLine("Customers: " + customers.Count);
            Debug.WriteLine("Tables: " + tables.Count);
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name");
            ViewData["TableId"] = new SelectList(tables, "Id", "Number");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var tableExists = await _context.Table.AnyAsync(t => t.Id == Reservation.TableId);
            var customerExists = await _context.Customer.AnyAsync(c => c.Id == Reservation.CustomerId);

            if (!tableExists || !customerExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid Table or Customer selected.");
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
