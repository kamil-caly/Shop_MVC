using Shop_MVC.Entities;

namespace Shop_MVC.Models.Basket
{
    public class BasketProduct : Product
    {
        public int BasketQuantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
