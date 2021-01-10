using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeProjectFinal.Model
{
    public class BikeType
    {
        public int ID { get; set; }
        public int BikeID { get; set; }

        public Bike Bike { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }


    }
}
