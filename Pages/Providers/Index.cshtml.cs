using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeProjectFinal.Data;
using BikeProjectFinal.Model;

namespace BikeProjectFinal.Pages.Providers
{
    public class IndexModel : PageModel
    {
        private readonly BikeProjectFinal.Data.BikeProjectFinalContext _context;

        public IndexModel(BikeProjectFinal.Data.BikeProjectFinalContext context)
        {
            _context = context;
        }

        public IList<Provider> Provider { get;set; }

        public async Task OnGetAsync()
        {
            Provider = await _context.Provider.ToListAsync();
        }
    }
}
