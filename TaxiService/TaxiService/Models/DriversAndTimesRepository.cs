using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Models
{
    public class DriversAndTimesRepository : IDriversAndTimesRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public DriversAndTimesRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public IEnumerable<DriversAndTimes> AllDriversAndTimes => _appDbContext.DriversAndTimes.Include(dat => dat.Time).Include(dat => dat.DriverPhoneNumberNavigation);

        public void AddDriverAndTime(int timeId, string driverPhone)
        {
            _appDbContext.DriversAndTimes.Add(new DriversAndTimes { TimeId = timeId, DriverPhoneNumber = driverPhone });
            _appDbContext.SaveChanges();
        }
        public void UpdateTimeId(DriversAndTimes currentDriverAndTime, int timeId)
        {

            if (AllDriversAndTimes.FirstOrDefault(dat => dat.DriverPhoneNumber == currentDriverAndTime.DriverPhoneNumber && dat.TimeId == timeId) == null)
            {
                _appDbContext.DriversAndTimes.Add(new DriversAndTimes { DriverPhoneNumber = currentDriverAndTime.DriverPhoneNumber, TimeId = timeId });
                _appDbContext.DriversAndTimes.Remove(currentDriverAndTime);
                _appDbContext.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
