using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using Shop_MVC.Entities;
using Shop_MVC.Entities.Enums;
using Shop_MVC.Models.Products;
using Shop_MVC.Models.Products.Enums;
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

            // category radioBtn
            if (filter.Category != null)
            {
                query = query.Where(p => p.Category == filter.Category);
            }

            // company radioBtn
            if (filter.Company != null)
            {
                query = query.Where(p => p.Company == filter.Company);
            }

            // color radioBtn
            if (filter.Color != null)
            {
                query = query.Where(p => p.Color == filter.Color);
            }

            // searchText input
            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(q => q.Name.ToLower().Contains(filter.SearchText.ToLower()));
            }

            // price sorting
            if (filter.PriceSort != null)
            {
                if (filter.PriceSort == Sort.Desc) query = query.OrderByDescending(q => q.Price);
                else query = query.OrderBy(q => q.Price);
            }

            return query.ToList();
        }

        public ProductDetailsViewModel GetProductsWithComments(string id)
        {
            ObjectId objId = ObjectId.Empty;
            if (ObjectId.TryParse(id, out ObjectId objectId))
            {
                objId = objectId;
            }
            else
            {
                throw new Exception(id + " is not a valid ObjectId.");
            }

            var product = dbCtx.Products.FirstOrDefault(p => p.Id == objId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            List<Comment> comments = dbCtx.Comments.Where(c => c.ProductId == objId).ToList();

            return new ProductDetailsViewModel
            {
                Product = product,
                Comments = comments
            };
        }
    }
}
