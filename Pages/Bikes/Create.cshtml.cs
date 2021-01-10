using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;

namespace BikeProjectFinal.Pages.Bikes
{
    public class CreateModel : BikeTypesPageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public CreateModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProviderID"] = new SelectList(_context.Set<Provider>(), "ID", "ProviderName");

            var bike = new Bike();
            bike.BikeTypes = new List<BikeType>();
            PopulateAssignedTypeData(_context, bike);


            return Page();
        }

        [BindProperty]
        public Bike Bike { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedTypes)
        {
            var newBike = new Bike();
            if (selectedTypes != null)
            {
                newBike.BikeTypes = new List<BikeType>();
                foreach (var cat in selectedTypes)
                {
                    var catToAdd = new BikeType
                    {
                        TypeID = int.Parse(cat)
                    };
                    newBike.BikeTypes.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Bike>(
                newBike,
                "Bike",
                i => i.Brand , i => i.Model,
                i => i.Price , i=>i.RestockDate, i=> i.ProviderID))
            {
                _context.Bike.Add(newBike);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedTypeData(_context, newBike);
            return Page();
        }
    }
}
