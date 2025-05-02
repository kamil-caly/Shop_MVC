using Shop_MVC.Entities;

namespace Shop_MVC.Models.Products
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; } = default!;
        public IEnumerable<Comment> Comments { get; set; } = default!;
    }
}
