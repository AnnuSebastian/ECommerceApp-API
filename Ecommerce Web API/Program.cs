using Ecommerce_Web_API.Database;
using Ecommerce_Web_API.Services.Categories;
using Ecommerce_Web_API.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            //category services
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            //product services
            builder.Services.AddScoped<IProductService, ProductService>();

            //database services
            builder.Services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //cors policy to avoid cross origin error
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200");
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors();


            app.MapControllers();

            app.Run();
        }
    }
}