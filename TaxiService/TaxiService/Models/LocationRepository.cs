using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public LocationRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public IEnumerable<Location> AllLocations => _appDbContext.Location;

        public int GetLocationsId(string location)
        {
           return _appDbContext.Location.FirstOrDefault(l => l.Location1 == location).LocationId;
        }
    }
}
