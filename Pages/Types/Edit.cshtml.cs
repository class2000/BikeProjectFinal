using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;
using Type = BikeProjectFinal.Model.Type;

namespace BikeProjectFinal.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public EditModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Type Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Type = await _context.Type.FirstOrDefaultAsync(m => m.ID == id);

            if (Type == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(Type.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.ID == id);
        }
    }
}
