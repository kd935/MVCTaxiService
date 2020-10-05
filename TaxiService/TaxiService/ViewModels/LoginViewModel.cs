using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это обязательное поле")]
        public string Password { get; set; }
    }
}
