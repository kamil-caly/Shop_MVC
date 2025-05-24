using Shop_MVC.Models.Basket;

namespace Shop_MVC.Services.Interfaces
{
    public interface IOrderService
    {
        bool Buy(IEnumerable<BasketProductLocalStorage> basketProducts);
    }
}
