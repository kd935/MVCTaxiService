using System;
using System.Collections.Generic;

namespace TaxiService.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Order = new HashSet<Order>();
        }

        public string ClientPhoneNumber { get; set; }
        public string ClientName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
