using MongoDB.Bson;

namespace Shop_MVC.Models.Basket
{
    public class BasketProductLocalStorage
    {
        public string Id { get; set; } = default!;
        public int Quantity { get; set; } = default!;
    }
}
