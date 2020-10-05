using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string ClientPhoneNumber { get; set; }
        public int LocationId { get; set; }
        public string Comforts { get; set; }
        public int OrderTimeId { get; set; }
        public int MinimalPrice { get; set; }
        public string OrderStatus { get; set; }

        public virtual Clients ClientPhoneNumberNavigation { get; set; }
        public virtual Drivers DriverPhoneNumberNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual Time OrderTime { get; set; }
    }
}
