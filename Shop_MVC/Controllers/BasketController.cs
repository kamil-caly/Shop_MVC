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
        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
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
    }
}
