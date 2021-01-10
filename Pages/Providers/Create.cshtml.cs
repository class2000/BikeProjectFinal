using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;

namespace BikeProjectFinal.Pages.Providers
{
    public class CreateModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public CreateModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Provider Provider { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Provider.Add(Provider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
