using Shop_MVC.Entities;

namespace Shop_MVC.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
