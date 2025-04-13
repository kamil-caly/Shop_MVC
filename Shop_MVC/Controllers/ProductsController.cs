using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }
    }
}
