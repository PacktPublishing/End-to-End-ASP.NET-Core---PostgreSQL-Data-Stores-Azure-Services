using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neon.CRM.WebApp.Data;
using Neon.CRM.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Neon.CRM.WebApp.Pages.Customers
{
    public class CreateModel(TenantDbContextFactory tenantDbContextFactory) : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer.AgentId = userId;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var _context = tenantDbContextFactory.Create();
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
