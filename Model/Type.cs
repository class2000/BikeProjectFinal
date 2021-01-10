using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProjectFinal.Model
{
    public class Type
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public ICollection<BikeType> Biketypes { get; set; }

    }
}
