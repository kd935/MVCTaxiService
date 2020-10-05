using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.Models
{
    public class PreOrderInfoViewModel
    {
        [StringLength(12)]
        [MinLength(12, ErrorMessage = "Неверная длинна номера")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        [Required(ErrorMessage = "Номер телефона является обязательным полем")]
        public string ClientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Имя является обязательным полем")]
        [RegularExpression(@"[А-Яа-я]{1,20}", ErrorMessage = "Неверный формат имени")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Местоположение является обязательным полем")]
        [RegularExpression(@"[А-Яа-я\s]{5,30}[^,],\s{1}[0-9]{1,4}", ErrorMessage = "Неверный формат местоположения")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Дата является обязательным полем")]
        public DateTime OrderDateTime { get; set; }
        public string SelectedVehicleType { get; set; }
        public string Comforts { get; set; }
        public int MinimalPrice { get; set; }
    }
}
