using Shop_MVC.Entities;
using Shop_MVC.Entities.Enums;
using Shop_MVC.Models.Products;
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

        public IEnumerable<Product> GetFilteredProducts(ProductsFilter? filter)
        {
            if (filter == null)
            {
                return dbCtx.Products.ToList();
            }

            var query = dbCtx.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Category) && filter.Category != "All")
            {
                if (Enum.TryParse<Category>(filter.Category, out var parsedCategory))
                    query = query.Where(p => p.Category == parsedCategory);
            }

            if (!string.IsNullOrEmpty(filter.Company) && filter.Company != "All")
            {
                if (Enum.TryParse<Company>(filter.Company, out var parsedCompany))
                    query = query.Where(p => p.Company == parsedCompany);
            }

            if (!string.IsNullOrEmpty(filter.Color) && filter.Color != "All")
            {
                if (Enum.TryParse<Color>(filter.Color, out var parsedColor))
                    query = query.Where(p => p.Color == parsedColor);
            }

            return query.ToList();
        }
    }
}
