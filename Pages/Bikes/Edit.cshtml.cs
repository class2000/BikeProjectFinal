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

namespace BikeProjectFinal.Pages.Bikes
{
    public class EditModel : BikeTypesPageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public EditModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bike Bike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bike = await _context.Bike.Include(b => b.Provider).Include(b => b.BikeTypes).ThenInclude(b => b.Type).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Bike == null)
            {
                return NotFound();
            }

            PopulateAssignedTypeData(_context, Bike);
            ViewData["ProviderID"] = new SelectList(_context.Set<Provider>(), "ID", "ProviderName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedTypes)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bikeToUpdate = await _context.Bike.Include(i => i.Provider).Include(i => i.BikeTypes).ThenInclude(i => i.Type)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bikeToUpdate == null)
            {
                return NotFound();
            }
            
            if(await TryUpdateModelAsync<Bike>(bikeToUpdate, "Bike" , i => i.Brand, i => i.Model, i => i.Price, i => i.RestockDate, i => i.Provider))
            {
                UpdateBikeType(_context, selectedTypes, bikeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateBikeType(_context, selectedTypes, bikeToUpdate);
            PopulateAssignedTypeData(_context, bikeToUpdate);
            return Page();
                    
        }

        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.ID == id);
        }
    }
}
