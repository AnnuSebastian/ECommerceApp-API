using Ecommerce_Web_API.Models;

namespace Ecommerce_Web_API.Services.Products
{
    public interface IProductService
    {
        List<Product> GetProducts();

        List<Product> GetProductByCatId(int catId);

        Product GetProductById(int id);

        Product AddProduct(int catId,Product product);

        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
