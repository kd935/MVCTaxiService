using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> AllLocations { get; }
        int GetLocationsId(string location);

    }
}
