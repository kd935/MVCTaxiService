using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;
using TaxiService.ViewModels;
using static TaxiService.Models.Enums;

namespace TaxiService.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private const string DefaultDriverStatus = "Свободен";
        private const string DefaultOrderStatus = "Новые";
        private readonly TaxiServiceContext _appDbContext;
        private readonly List<NewOrder> _newOrderStorage;
        private readonly ITimeRepository _timeRepository;
        private readonly IDriversAndTimesRepository _diversAndTimesRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IClientsRepository _clientsRepository;
        private readonly ILocationRepository _locationRepository;

        public AdminController(TaxiServiceContext taxiServiceContext, List<NewOrder> newOrderStorage, ITimeRepository timeRepository, IDriversAndTimesRepository diversAndTimesRepository, IOrderRepository orderRepository, IClientsRepository clientsRepository, ILocationRepository locationRepository)
        {
            _appDbContext = taxiServiceContext;
            _newOrderStorage = newOrderStorage;
            _timeRepository = timeRepository;
            _diversAndTimesRepository = diversAndTimesRepository;
            _orderRepository = orderRepository;
            _clientsRepository = clientsRepository;
            _locationRepository = locationRepository;
        }
        public IActionResult Index()
        {
            AdminIndexViewModel adminIndexViewModel = new AdminIndexViewModel();
            return View(adminIndexViewModel);
        }

        public IActionResult Drivers(int? id)
        {
            _appDbContext.Database.ExecuteSqlRaw("assign_driver");

            if (id == null) {
                DriversViewModel driversViewModel = new DriversViewModel();
                return View(driversViewModel);
            }
            else
            {
                DriversViewModel driversViewModel = new DriversViewModel();
                driversViewModel.DriverStatus = DefaultDriverStatus;

                if (_newOrderStorage.ElementAtOrDefault(id.Value) == null)
                {
                    
                }
                else
                {
                    TempData["AssignDriverMode"] = true;
                    TempData["OrderId"] = id.Value;

                    driversViewModel.VehicleType = _newOrderStorage.ElementAt(id.Value).SelectedVehicleType;
                }
                return View(driversViewModel);
            }
        }
        public IActionResult DriversRadioButtonHandler(string id)
        {

            if (id == null) {
                TempData.Clear();
                return ViewComponent("DriversList", new { selectedStatus = "", selectedVehicleType = "" });
            }

            var parameters = id.Split(" ");
            string name = parameters[0];
            string value = parameters[1];
            TempData[name] = value;

            switch (name)
            {
                case "DriverStatus":
                    if(TempData.Peek("VehicleType") != null)
                    {
                        return ViewComponent("DriversList", new { selectedStatus = value, selectedVehicleType = TempData.Peek("VehicleType") });
                    }
                    else
                    {
                        return ViewComponent("DriversList", new { selectedStatus = value, selectedVehicleType = "" });
                    }
                    break;
                case "VehicleType":
                    ViewData["AssignDriverMode"] = TempData["AssignDriverMode"];
                    if (TempData.Peek("DriverStatus") != null)
                    {
                        return ViewComponent("DriversList", new { selectedStatus = TempData.Peek("DriverStatus"), selectedVehicleType = value });
                    }
                    else
                    {
                        return ViewComponent("DriversList", new { selectedStatus = "", selectedVehicleType = value });
                    }
                    break;
            }
            return ViewComponent("DriversList", new { selectedStatus = "", selectedVehicleType = "" });
        }

        public IActionResult IndexRadioButtonHandler(string id)
        {
            switch(id)
            {
                case DefaultOrderStatus:
                    return ViewComponent("NewOrderList");
                    break;
                case "В процессе":
                    return ViewComponent("InProgressOrderList");
                    break;
                case "Выполненные":
                    return ViewComponent("CompletedOrderList");
                    break;
                case "Отменённые":
                    return ViewComponent("CanceledOrderList");
                    break;
            }
            return RedirectToAction("Index");
        }

        public IActionResult AssignDriver(string driverphone, string vehicletype)
        {
            int orderId = (int)TempData["OrderId"];
            Time addedTime = _timeRepository.AddTime(_newOrderStorage[orderId].OrderDateTime);
            _diversAndTimesRepository.AddDriverAndTime(addedTime.Id, driverphone);
            _clientsRepository.AddClient(_newOrderStorage[orderId].ClientName, _newOrderStorage[orderId].ClientPhoneNumber);
            int locationId = _locationRepository.GetLocationsId(_newOrderStorage[orderId].Location);
            _orderRepository.AddOrder(driverphone, _newOrderStorage[orderId].ClientPhoneNumber, locationId, _newOrderStorage[orderId].Comforts, addedTime.Id, _newOrderStorage[orderId].MinimalPrice, OrderStatuses.InProgress);

            _newOrderStorage.RemoveAt(orderId);

            _appDbContext.Database.ExecuteSqlRaw("assign_driver");

            return ViewComponent("DriversList", new { selectedStatus = DefaultDriverStatus, selectedVehicleType = vehicletype });
        }

        public IActionResult DeclineOrder(int id) {
            _newOrderStorage.RemoveAt(id);
            AdminIndexViewModel adminIndexViewModel = new AdminIndexViewModel();
            adminIndexViewModel.OrderStatus = DefaultOrderStatus;
            return View("Index", adminIndexViewModel);
        }

        public IActionResult EditOrder(int orderId)
        {

            return ViewComponent("InProgressOrderList", new { orderId = orderId} );
        }

        public IActionResult UpdateOrder(int orderid, string location, string comforts, int minimalprice, DateTime ordertime, string orderstatus)
        {
            Order orderToUpdate = _orderRepository.AllOrders.FirstOrDefault(o => o.Id == orderid);

            Time addedTime = null;
            var time = _timeRepository.AllTimes.FirstOrDefault(t => t.Time1 == ordertime);

            if (time == null)
            {
                addedTime = _timeRepository.AddTime(ordertime);
            }
            else
            {
                addedTime = time;
            }

            var driverAndTime = _diversAndTimesRepository.AllDriversAndTimes.FirstOrDefault(dat => dat.DriverPhoneNumber == orderToUpdate.DriverPhoneNumber && dat.TimeId == orderToUpdate.OrderTimeId);

            _diversAndTimesRepository.UpdateTimeId(driverAndTime, addedTime.Id);

            var orderlocation = _locationRepository.AllLocations.FirstOrDefault(l => l.Location1 == location);

            try
            {
                _orderRepository.UpdateOrder(orderToUpdate, orderlocation.LocationId, minimalprice, addedTime.Id, comforts, orderstatus);
            }
            catch (Exception e)
            {

            }
            return ViewComponent("InProgressOrderList");
        }
    }
}
