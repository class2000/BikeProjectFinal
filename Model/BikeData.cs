using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProjectFinal.Model
{
    public class BikeData
    {
        public IEnumerable<Bike> Bikes { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<BikeType> BikeTypes { get; set; }
    }
}
