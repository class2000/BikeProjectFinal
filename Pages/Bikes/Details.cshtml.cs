using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;

namespace BikeProjectFinal.Pages.Bikes
{
    public class DetailsModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public DetailsModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        public Bike Bike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bike = await _context.Bike.FirstOrDefaultAsync(m => m.ID == id);

            if (Bike == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
