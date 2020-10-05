using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaxiService.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TaxiServiceContext _appDbContext;
        public OrderRepository(TaxiServiceContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public IEnumerable<Order> AllOrders => _appDbContext.Order.Include(o => o.Location).Include(o => o.OrderTime).Include(o => o.ClientPhoneNumberNavigation).Include(o => o.DriverPhoneNumberNavigation);

        public Order AddOrder(string driverPhoneNumber, string clientPhoneNumber, int locationId, string comforts, int orderTimeId, int minimalPrice, string orderStatus)
        {
            Order order = new Order { Id = _appDbContext.GetMySequence(), ClientPhoneNumber = clientPhoneNumber, DriverPhoneNumber = driverPhoneNumber, 
                Comforts = comforts, LocationId = locationId, OrderTimeId = orderTimeId, MinimalPrice = minimalPrice, OrderStatus = orderStatus};
            _appDbContext.Order.Add(order);
            _appDbContext.SaveChanges();
            return order;
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }
        public void UpdateOrder(Order orderToUpdate, int locationId, int minimalPrice, int orderTimeId, string comforts, string orderStatus)
        {
           
            orderToUpdate.LocationId = locationId;
            orderToUpdate.MinimalPrice = minimalPrice;
            orderToUpdate.OrderTimeId = orderTimeId;
            orderToUpdate.Comforts = comforts;
            orderToUpdate.OrderStatus = orderStatus;

            _appDbContext.SaveChanges();

        }

    }
}
