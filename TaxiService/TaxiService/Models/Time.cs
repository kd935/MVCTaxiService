using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiService.Models
{
    public partial class Time
    {
        public Time()
        {
            DriversAndTimes = new HashSet<DriversAndTimes>();
            Order = new HashSet<Order>();
        }
        public int Id { get; set; }
        public DateTime Time1 { get; set; }

        public virtual ICollection<DriversAndTimes> DriversAndTimes { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
