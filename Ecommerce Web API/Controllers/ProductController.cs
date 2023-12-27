using Ecommerce_Web_API.Models;
using Ecommerce_Web_API.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //all products

        [HttpGet]

        public ActionResult<List<Product>> GetAllProducts()
        {
            var data = _productService.GetProducts();
            return Ok(data);
        }

        // get product by category id
        [HttpGet("category/{catId}")]

        public ActionResult<List<Product>> GetProductByCatId(int catId)
        {
            var data = _productService.GetProductByCatId(catId);
            if(data == null) 
                return NotFound("No product eas found with catId :"+catId);
            return Ok(data);
        }

        //get product by Id
        [HttpGet("{id}")]

        public ActionResult<Product> GetProduct(int id)
        {
            var data = _productService.GetProductById(id);
            if(data == null)
                return NotFound("No product was found with id: "+id);
            return Ok(data);
        }

        //add product
        [HttpPost("{catId}")]

        public ActionResult<Product> PostProduct(int catId,Product product)
        {
            var data = _productService.AddProduct(catId,product);
            if(data == null )
                return BadRequest();
            return Created("Data created", data);
        }

        //update product
        [HttpPut("{id}")]

        public ActionResult<Product> PutProduct(int id, [FromBody] Product product) 
        {
            var data = _productService.GetProductById(id);
            if (data == null)
                return NotFound("No product was found with id: " + id);
            var response = _productService.UpdateProduct(id, product);
            return Ok(response);
        }

        //delete product
        [HttpDelete("{id}")]

        public ActionResult<string> DeleteProduct(int id)
        {
            var data = _productService.GetProductById(id);
            if (data == null)
                return NotFound("No category found with id: " + id);
            _productService.DeleteProduct(id);
            return Ok("Product Deleted");
        }
    }
}
