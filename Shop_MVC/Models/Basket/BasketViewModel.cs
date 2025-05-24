using Shop_MVC.Entities;

namespace Shop_MVC.Models.Basket
{
    public class BasketViewModel
    {
        public List<BasketProduct> Products { get; set; } = default!;
        public decimal TotalPrice { get; set; }
    }
}
