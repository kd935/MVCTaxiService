using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiService.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace TaxiService.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);

                if (signInResult.Succeeded)
                {
                    TempData.Put<string>("alertMessage", $"<script>alert('Вы успешно авторизовались как {loginViewModel.Email}');</script>");
                    return RedirectToAction("Index","Admin");
                }
                ModelState.AddModelError(String.Empty, "Неверное имя пользователя или пароль");
            }
            return View(loginViewModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
