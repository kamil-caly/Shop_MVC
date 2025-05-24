using Shop_MVC.Models.Basket;
using System.Dynamic;

namespace Shop_MVC.Services.Interfaces
{
    public interface IBasketService
    {
        BasketViewModel GetBasket(IEnumerable<BasketProductLocalStorage> basketProducts);
    }
}
