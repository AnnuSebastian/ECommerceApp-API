using Ecommerce_Web_API.Models;
using Ecommerce_Web_API.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //all categories
        [HttpGet]

        public ActionResult<List<Category>> GetAllCategories()
        {
            var data = _categoryService.GetCategories();
            return Ok(data);//response 200 + data
        }

        //get category by id
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("No category found with id: " + id);
            return Ok(data);
        }

        //add category
        [HttpPost]
        public ActionResult<Category> PostCategory([FromBody] Category category)
        {
            var data = _categoryService.AddCategory(category);
            if (data == null)
                return BadRequest();
            return Created("Data created", data);
        }

        //update category

        [HttpPut("{id}")]
        public ActionResult<Category> PutCategory(int id, [FromBody] Category category)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
                return NotFound("No category found with id: " + id);
            var response=_categoryService.UpdateCategory(id, category);
            return Ok(response);
        }

        //delete category
        [HttpDelete("{id}")]

        public ActionResult DeleteCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if(data == null)
                return NotFound("No category found with id: " + id);
            _categoryService.DeleteCategory(id);
            return Ok("Category Deleted");
        }
    }
}
