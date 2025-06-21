using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Models.Basket;
using Shop_MVC.Models.Products;
using Shop_MVC.Services;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;
        public BasketController(IBasketService basketService, IOrderService orderService)
        {
            this.basketService = basketService;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View(new BasketViewModel() { Products = [] });
        }

        [HttpPost]
        public IActionResult GetBasket([FromBody] IEnumerable<BasketProductLocalStorage> basketProducts)
        {
            var basket = basketService.GetBasket(basketProducts);
            return PartialView("Index", basket);
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
                return Json(new
                {
                    success = false,
                    message = ex.Message,
                    type = "danger"
                });
            }

            if (result)
            {
                return Json(new
                {
                    success = true,
                    message = "Purchase Completed",
                    type = "success"
                });
            }

            return Json(new
            {
                success = false,
                message = "Something went wrong",
                type = "danger"
            });
        }
    }
}
