using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class DriversListViewModel
    {
        public IEnumerable<Drivers> Drivers { get; set; }

        public IEnumerable<Time> Times { get; set; }
    }
}
