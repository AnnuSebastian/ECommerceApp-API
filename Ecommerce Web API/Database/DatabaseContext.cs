using Ecommerce_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Web_API.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
