using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeProjectFinal.Model
{
    public class Bike
    {
        public int ID { get; set; }
        [Display(Name = "Bike Brand")]
        public string Brand { get; set; }
        public string Model { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime RestockDate { get; set; }

        public int ProviderID { get; set; } 
        public Provider Provider { get; set; }

        public ICollection<BikeType>BikeTypes { get; set; }

    }
}
