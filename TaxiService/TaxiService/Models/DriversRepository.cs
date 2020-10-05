using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Models
{
    public class DriversRepository : IDriversRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public DriversRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public IEnumerable<Drivers> AllDrivers => _appDbContext.Drivers.Include(d => d.Vehicle).Include(d => d.Location).Include(d => d.DriversAndTimes);

        public Drivers GetDriverByPhoneNumber(string driverPhoneNumber)
        {
            return _appDbContext.Drivers.FirstOrDefault(d => d.DriverPhoneNumber == driverPhoneNumber);
        }
        public IEnumerable<Drivers> GetDriversByStatus(string driverStatus)
        {
            return _appDbContext.Drivers.Include(d => d.Vehicle).Include(d => d.Location).Include(d => d.DriversAndTimes).Where(d => d.DriverStatus == driverStatus);
        }
        static public IEnumerable<Drivers> GetDriversFromCollectionByVehicleType(IEnumerable<Drivers> drivers, string vehicleType)
        {
            return drivers.Where(d => d.Vehicle.VehicleType == vehicleType);
        }
    }
}
