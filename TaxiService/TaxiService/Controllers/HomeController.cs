using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxiService.Models;
using TaxiService.ViewModels;


namespace TaxiService.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<NewOrder> _newOrderStorage;

        public HomeController(List<NewOrder> newOrderStorage)
        {
            _newOrderStorage = newOrderStorage;
        }
        public IActionResult Index()
        {
            return View(new SelectedVehicleDetailsViewModel());
        }
        [HttpPost]
        public IActionResult Index(SelectedVehicleDetailsViewModel preOrderDetails)
        {
            if (ModelState.IsValid)
            {
                TempData.Put("preOrederDetails", preOrderDetails);
                return RedirectToAction("UserOrderInfo");
            }
            return View(preOrderDetails);
        }
        public IActionResult UserOrderInfo()
        {
            var preOrderDetails = TempData.Get<SelectedVehicleDetailsViewModel>("preOrederDetails");
            TempData.Keep("preOrederDetails");
            PreOrderInfoViewModel preOrderInfo = new PreOrderInfoViewModel();
            preOrderInfo.SelectedVehicleType = preOrderDetails.SelectedVehicleType;
            var selectedComfortsNames = preOrderDetails.AdditionalComforts.FindAll(x => x.IsSelected == true).Select(x => x.Name);
            if (selectedComfortsNames.Count() != 0)
            {
                preOrderInfo.Comforts = selectedComfortsNames.Aggregate((x, y) => $"{x}, {y}");
                preOrderInfo.MinimalPrice = preOrderDetails.AdditionalComforts.FindAll(x => x.IsSelected == true).Select(x => x.Price).Aggregate((x, y) => x + y) + preOrderDetails.VehicleTypes.Find(x => x.Name == preOrderDetails.SelectedVehicleType).Price;

            }
            else
            {
                preOrderInfo.Comforts = "";
                preOrderInfo.MinimalPrice = preOrderDetails.VehicleTypes.Find(x => x.Name == preOrderDetails.SelectedVehicleType).Price;
            }
            return View(preOrderInfo);
        }
        [HttpPost]
        public IActionResult UserOrderInfo(PreOrderInfoViewModel preOrderInfo)
        {
            if (ModelState.IsValid)
            {
                _newOrderStorage.Add((NewOrder)preOrderInfo);
                TempData.Put<string>("alertMessage", "<script>alert('Ваш заказ успешно оформлен. Ожидайте дальнейших уведомлений.');</script>");
                return RedirectToAction("Index");
            }
            return View(preOrderInfo);
        }
    }
}
