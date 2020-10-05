using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;
using static TaxiService.Models.Enums;

namespace TaxiService.Components
{
    public class InProgressOrderList : ViewComponent
    {
        private readonly IOrderRepository _orderRepository;

        public InProgressOrderList(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IViewComponentResult Invoke(int? orderId)
        {
            ViewData["OrderId"] = orderId;

            return View(_orderRepository.AllOrders.Where(o => o.OrderStatus == OrderStatuses.InProgress));
        }
    }
}
