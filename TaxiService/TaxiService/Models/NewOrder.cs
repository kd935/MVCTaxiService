using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public class NewOrder
    {
        public string ClientPhoneNumber { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string SelectedVehicleType { get; set; }
        public string Comforts { get; set; }
        public int MinimalPrice { get; set; }

        public static explicit operator NewOrder(PreOrderInfoViewModel p)
        {
            return new NewOrder { 
                ClientPhoneNumber = p.ClientPhoneNumber, 
                ClientName = p.ClientName,
                Location = p.Location,
                OrderDateTime = p.OrderDateTime, 
                SelectedVehicleType = p.SelectedVehicleType,
                Comforts = p.Comforts,
                MinimalPrice = p.MinimalPrice };
        }
    }
}
