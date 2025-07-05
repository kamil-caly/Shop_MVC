using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Shop_MVC.Models.UserManager;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Controllers
{
    public class UserManagerController: Controller
    {
        private readonly IUserManagerService userMngService;
        public UserManagerController(IUserManagerService userManagerService)
        {
            userMngService = userManagerService;
        }
        public IActionResult Index()
        {
            var model = userMngService.GetUsers();
            return View(model);
        }

        public IActionResult AddMoney(string email)
        {
            var user = userMngService.GetByEmail(email);
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult AddMoney(UserManagerViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userMngService.AddMoney(user);
                    return RedirectToAction(nameof(Index));
                }

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ToastMessage"] = ex.Message;
                TempData["ToastType"] = "Error";
                return View(user);
            }
        }
    }
}
