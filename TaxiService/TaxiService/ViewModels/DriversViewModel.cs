using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.ViewModels
{
    public class DriversViewModel
    {
        public string VehicleType { get; set; }
        public List<string> VehcileTypes = new List<string> { "Стандарт", "Эко", "Комфорт", "Микроавтобус" };

        public string DriverStatus { get; set; }
        public List<string> DriverStatuses = new List<string> { "Свободен", "Занят" };
    }
}

