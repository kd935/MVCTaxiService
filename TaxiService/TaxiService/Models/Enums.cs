using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public class Enums
    {
        public static class OrderStatuses
        {
            public static string InProgress => "В процессе";
            public static string Completed => "Выполнен";
            public static string Canceled => "Отменён";
        }
    }
}
