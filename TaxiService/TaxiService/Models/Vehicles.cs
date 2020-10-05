using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Drivers = new HashSet<Drivers>();
        }

        public int Id { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }

        public virtual ICollection<Drivers> Drivers { get; set; }
    }
}
