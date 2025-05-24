using Shop_MVC.Entities;
using Shop_MVC.Models.Basket;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext dbCtx;
        public OrderService(ShopDbContext dbContext)
        {
            dbCtx = dbContext;
        }

        public bool Buy(IEnumerable<BasketProductLocalStorage> basketProducts)
        {
            throw new NotImplementedException();
        }
    }
}
