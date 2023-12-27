using Ecommerce_Web_API.Models;

namespace Ecommerce_Web_API.Services.Categories
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategoryById(int id);

        Category AddCategory(Category category);

        Category UpdateCategory(int id,Category category);

        void DeleteCategory(int id);
    }
}
