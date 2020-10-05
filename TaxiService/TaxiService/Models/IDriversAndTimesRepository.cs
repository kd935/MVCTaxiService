using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface IDriversAndTimesRepository
    {
        IEnumerable<DriversAndTimes> AllDriversAndTimes { get; }
        public void AddDriverAndTime(int timeId, string driverPhone);

        public void UpdateTimeId(DriversAndTimes currentDriverAndTime, int timeId);
    }
}
