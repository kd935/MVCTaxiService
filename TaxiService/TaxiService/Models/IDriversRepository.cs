using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface IDriversRepository
    {
        IEnumerable<Drivers> AllDrivers { get; }
        Drivers GetDriverByPhoneNumber(string driverPhoneNumber);
        public IEnumerable<Drivers> GetDriversByStatus(string driverStatus);
    }
}
