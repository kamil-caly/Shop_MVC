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
    }
}
