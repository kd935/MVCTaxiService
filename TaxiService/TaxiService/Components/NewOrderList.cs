using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;

namespace TaxiService.Components
{
    public class NewOrderList : ViewComponent
    {
        private readonly List<NewOrder> _newOrderStorage;
        public NewOrderList(List<NewOrder> newOrderStorage)
        {
            _newOrderStorage = newOrderStorage;
        }
        public IViewComponentResult Invoke()
        {
            return View(_newOrderStorage);
        }
    }
}
