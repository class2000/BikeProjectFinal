using System.Collections.Generic;

namespace BikeProjectFinal.Model
{
    public class Provider
    {
        public int ID { get; set; }
        public string ProviderName { get; set; }
        public ICollection<Bike> Bikes { get; set; }

    }
}