using MongoDB.Bson;
using Shop_MVC.Entities;
using Shop_MVC.Models.Basket;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Services
{
    public class BasketService: IBasketService
    {
        private readonly ShopDbContext dbCtx;
        public BasketService(ShopDbContext dbContext)
        {
            dbCtx = dbContext;
        }

        public BasketViewModel GetBasket(IEnumerable<BasketProductLocalStorage> basketProducts)
        {
            var result = new BasketViewModel();
            result.Products = new List<BasketProduct>();

            if (basketProducts == null || !basketProducts.Any()) return result;

            var dbProducts = dbCtx.Products
                .Where(p => basketProducts.Select(bp => bp.Id).ToList().Contains(p.Id.ToString()))
                .ToList();

            foreach (var dbProduct in dbProducts)
            {
                BasketProduct product = Copy(dbProduct);
                product.BasketQuantity = basketProducts.First(b => b.Id == product.Id.ToString()).Quantity;
                product.TotalPrice = (int)product.Price * product.BasketQuantity;
                result.Products.Add(product);
            }

            result.TotalPrice = result.Products.Sum(p => p.Price * p.BasketQuantity);

            return result;
        }

        private BasketProduct Copy(Product product)
        {
            return new BasketProduct
            {
                Id = product.Id,
                Name = product.Name,
                Img = product.Img,
                Price = product.Price,
                Color = product.Color,
                Company = product.Company,
                Category = product.Category,
                Quantity = product.Quantity
            };
        }
    }
}
