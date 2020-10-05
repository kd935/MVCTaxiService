using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.ViewModels
{
    public class AdminIndexViewModel
    {
        public string OrderStatus { get; set; }
        public List<string> OrderStatuses = new List<string> { "Новые", "В процессе", "Выполненные", "Отменённые" };

    }
}
