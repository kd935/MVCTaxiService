using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> AllOrders { get; }
        Order GetOrderById(int orderId);
        Order AddOrder(string DriverPhoneNumber, string ClientPhoneNumber, int LocationId, string Comforts, int OrderTimeId, int MinimalPrice, string OrderStatus);
        void UpdateOrder(Order orderToUpdate, int locationId, int minimalPrice, int orderTimeId, string comforts, string orderStatus);
    }
}
