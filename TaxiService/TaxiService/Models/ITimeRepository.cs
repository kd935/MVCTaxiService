using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface ITimeRepository
    {
        IEnumerable<Time> AllTimes { get; }
        Time GetTimeById(int id);
        public Time AddTime(DateTime time);
    }
}
