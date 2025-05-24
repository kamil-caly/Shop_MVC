using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Models.Basket;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy([FromBody] IEnumerable<BasketProductLocalStorage> basketProducts)
        {
            bool result = false;

            try
            {
                result = orderService.Buy(basketProducts);
            }
            catch (Exception ex)
            {
                TempData["ToastMessage"] = ex.Message;
                TempData["ToastType"] = "danger";
                return StatusCode(500, ex.Message);
            }
            
            if (result)
            {
                TempData["ToastMessage"] = "Purchase Completed";
                TempData["ToastType"] = "success";
                return StatusCode(200);
            }

            TempData["ToastMessage"] = "Something went wrong";
            TempData["ToastType"] = "danger";
            return StatusCode(500);
        }
    }
}
