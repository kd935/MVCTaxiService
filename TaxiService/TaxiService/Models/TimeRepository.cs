using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public class TimeRepository : ITimeRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public TimeRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public IEnumerable<Time> AllTimes => _appDbContext.Time;

        public Time GetTimeById(int id) => _appDbContext.Time.Find(id);

        public Time AddTime(DateTime time) {
            Time _time = new Time { Id = _appDbContext.GetMySequence(), Time1 = time };
            _appDbContext.Time.Add(_time);
            //_appDbContext.SaveChanges();
            return _time;
        }
    }
}
