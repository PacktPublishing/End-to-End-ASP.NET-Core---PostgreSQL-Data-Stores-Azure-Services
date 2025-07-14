using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neon.CRM.WebApp.Data;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Neon.CRM.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(Neon.CRM.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Customers"] = new SelectList(_context.Customers, "Id", "FullName");
        ViewData["VacationPackageId"] = new SelectList(_context.VacationPackages, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Booking.BookingDate = Booking.BookingDate.ToUniversalTime();
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
