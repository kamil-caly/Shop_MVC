using Shop_MVC.Entities.Enums;
using Shop_MVC.Models.Products.Enums;

namespace Shop_MVC.Models.Products
{
    public class ProductsFilter
    {
        public Category? Category { get; set; }
        public Company? Company { get; set; }
        public Color? Color { get; set; }
        public string? SearchText { get; set; }
        public Sort? PriceSort { get; set; }
    }
}
