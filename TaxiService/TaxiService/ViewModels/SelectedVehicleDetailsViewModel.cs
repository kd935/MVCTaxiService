using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.Models;

namespace TaxiService.ViewModels
{
    public class SelectedVehicleDetailsViewModel
    {
        public List<VehicleType> VehicleTypes = new List<VehicleType> {
             new VehicleType { Name = "Стандарт", Price = 45, IsSelected = false },
             new VehicleType { Name = "Эко", Price = 35, IsSelected = false },
             new VehicleType { Name = "Комфорт", Price = 60, IsSelected = false },
             new VehicleType { Name = "Микроавтобус", Price = 80, IsSelected = false }
        };

        [Required(ErrorMessage = "Необходимо выбрать тип авто")]
        public string SelectedVehicleType { get; set; }
        public List<AdditionalComfort> AdditionalComforts { get; set; } = new List<AdditionalComfort> {
            new AdditionalComfort { Name = "Багаж в салоне", Price = 25, IsSelected = false },
            new AdditionalComfort { Name = "Прикуриватель", Price = 50, IsSelected = false },
            new AdditionalComfort { Name = "Буксировка", Price = 90, IsSelected = false },
            new AdditionalComfort { Name = "Перевозка животного", Price = 10, IsSelected = false },
            new AdditionalComfort { Name = "Детское кресло", Price = 10, IsSelected = false },
            new AdditionalComfort { Name = "Кондиционер", Price = 10, IsSelected = false },
            new AdditionalComfort { Name = "Автопилот", Price = 90, IsSelected = false }
        };
    }
}
