using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class DriversAndTimes
    {
        public int TimeId { get; set; }
        public string DriverPhoneNumber { get; set; }

        public virtual Drivers DriverPhoneNumberNavigation { get; set; }
        public virtual Time Time { get; set; }
    }
}
