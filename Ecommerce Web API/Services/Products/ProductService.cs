using Ecommerce_Web_API.Database;
using Ecommerce_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Web_API.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }
        public Product AddProduct(int catId,Product product)
        {
            //find the category by catId
            Category category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == catId);

            //set category for the product
            product.productCategory = category;
            
            //add new product
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            Product productSaved= GetProductById(id);
            _context.Products.Remove(productSaved);
            _context.SaveChanges();
        }

        public List<Product> GetProductByCatId(int catId)
        {
            return _context.Products.Where(x => x.productCategory.CategoryId== catId).Include(x=>x.productCategory).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x => x.productId == id).Include(x => x.productCategory).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(c => c.productCategory).ToList();
        }

        public Product UpdateProduct(int id, Product product)
        {
            Product productSaved = GetProductById(id);
            productSaved.productTitle = product.productTitle;
            productSaved.productPrice = product.productPrice;
            productSaved.productDescription = product.productDescription;
            productSaved.productImage = product.productImage;
            productSaved.productCategory = _context.Categories.FirstOrDefault(x => x.CategoryId==productSaved.productCategory.CategoryId) ;
            _context.SaveChanges();
            return productSaved;
        }

    }
}
