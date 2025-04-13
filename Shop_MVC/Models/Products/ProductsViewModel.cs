using Shop_MVC.Entities;
using Shop_MVC.Entities.Enums;

namespace Shop_MVC.Models.Products
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; } = default!;
        public IEnumerable<Category> Categories { get; set; } = default!;
        public IEnumerable<Company> Companies { get; set; } = default!;
        public IEnumerable<Color> Colors { get; set; } = default!;
    }
}
