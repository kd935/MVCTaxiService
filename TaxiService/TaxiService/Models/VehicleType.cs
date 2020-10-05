using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public class VehicleType
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsSelected { get; set; }
    }
}
