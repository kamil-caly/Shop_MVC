using MongoDB.Bson;
using Shop_MVC.Entities;
using Shop_MVC.Models.Products;

namespace Shop_MVC.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetFilteredProducts(ProductsFilter? filter);
        ProductDetailsViewModel GetProductsWithComments(string id);
    }
}
