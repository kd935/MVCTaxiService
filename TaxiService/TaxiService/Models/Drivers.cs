using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class Drivers
    {
        public Drivers()
        {
            DriversAndTimes = new HashSet<DriversAndTimes>();
            Order = new HashSet<Order>();
        }

        public string DriverPhoneNumber { get; set; }
        public int LocationId { get; set; }
        public string DriverStatus { get; set; }
        public int VehicleId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual ICollection<DriversAndTimes> DriversAndTimes { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
