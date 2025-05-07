using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Models.Account;
using Shop_MVC.Models.Account.Enums;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Controllers
{
    public class AccountController: Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = accountService.Register(model);

            if (result == RegisterResult.EmailAlreadyExists)
            {
                TempData["ToastMessage"] = "Email already in use!";
                TempData["ToastType"] = "danger";
                return View(model);
            }

            TempData["ToastMessage"] = "Account created successfully!";
            TempData["ToastType"] = "success";
            
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = accountService.Login(model);

            if (result == LoginResult.WrongEmailOrPassword)
            {
                TempData["ToastMessage"] = "Wrong email or password!";
                TempData["ToastType"] = "danger";
                return View(model);
            }

            TempData["ToastMessage"] = "Login success!";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Logout()
        {
            accountService.Logout();

            TempData["ToastMessage"] = "Logout success!";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index", "Products");
        }
    }
}
