using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class Location
    {
        public Location()
        {
            Drivers = new HashSet<Drivers>();
            Order = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public string Location1 { get; set; }

        public virtual ICollection<Drivers> Drivers { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
