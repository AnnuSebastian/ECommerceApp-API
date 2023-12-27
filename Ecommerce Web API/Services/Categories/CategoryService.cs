﻿using Ecommerce_Web_API.Database;
using Ecommerce_Web_API.Models;

namespace Ecommerce_Web_API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            Category categorySaved = GetCategoryById(id);
            _context.Categories.Remove(categorySaved);
            _context.SaveChanges();
           
        }

        public List<Category> GetCategories()
        {
           return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(cat => cat.CategoryId == id);
        }

        public Category UpdateCategory(int id,Category category)
        {
            Category categorySaved= GetCategoryById(id);
            categorySaved.CategoryName = category.CategoryName;
            categorySaved.CategoryImage = category.CategoryImage;
            _context.SaveChanges();
            return categorySaved;
        }
    }
}