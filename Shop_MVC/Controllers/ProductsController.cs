using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Shop_MVC.Entities.Enums;
using Shop_MVC.Models.Products;
using Shop_MVC.Services;
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
            var categories = Enum.GetValues(typeof(Category)).Cast<Category>();
            var companies = Enum.GetValues(typeof(Company)).Cast<Company>();
            var colors = Enum.GetValues(typeof(Color)).Cast<Color>();

            var model = new ProductsViewModel
            {
                Products = productService.GetProducts(),
                Categories = categories,
                Companies = companies,
                Colors = colors
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Filter([FromBody] ProductsFilter filter)
        {
            var filteredProducts = productService.GetFilteredProducts(filter);
            return PartialView("_ProductsPartial", filteredProducts);
        }

        [Route("Products/Details/{Id}")]
        public IActionResult Details(string Id)
        {
            try
            {
                var model = productService.GetProductsWithComments(Id);
                return View(model);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
