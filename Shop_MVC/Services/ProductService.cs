using Shop_MVC.Entities;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopDbContext dbCtx;
        public ProductService(ShopDbContext dbContext)
        {
            dbCtx = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbCtx.Products.ToList();
        }
    }
}
