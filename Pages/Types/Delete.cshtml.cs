using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;
using Type = BikeProjectFinal.Model.Type;

namespace BikeProjectFinal.Pages.Types
{
    public class DeleteModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public DeleteModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Type = await _context.Type.FindAsync(id);

            if (Type != null)
            {
                _context.Type.Remove(Type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
