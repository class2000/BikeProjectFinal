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
    public class IndexModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public IndexModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        public IList<Bike> Bike { get;set; }
        public BikeData BikeD { get; set; }
        public int BikeID { get; set; }
        public int TypeID { get; set; }
        public async Task OnGetAsync(int? id, int? typeID)
        {
            BikeD = new BikeData();

            BikeD.Bikes = await _context.Bike
                .Include(b => b.Provider)
                .Include(b => b.BikeTypes)
                .ThenInclude(b => b.Type)
                .AsNoTracking()
                .OrderBy(b => b.Brand)
                .ToListAsync();

            if (id != null)
            {
                BikeID = id.Value;
                Bike bike = BikeD.Bikes
                    .Where(i => i.ID == id.Value).Single();
                BikeD.Types = bike.BikeTypes.Select(s => s.Type);

            }

        }
       
    }
}
