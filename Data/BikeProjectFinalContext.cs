using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikeProjectFinal.Model;

namespace BikeProjectFinal.Data
{
    public class BikeProjectFinalContext : DbContext
    {
        public BikeProjectFinalContext (DbContextOptions<BikeProjectFinalContext> options)
            : base(options)
        {
        }

        public DbSet<BikeProjectFinal.Model.Bike> Bike { get; set; }

        public DbSet<BikeProjectFinal.Model.Provider> Provider { get; set; }

        public DbSet<BikeProjectFinal.Model.Type> Type { get; set; }
    }
}
