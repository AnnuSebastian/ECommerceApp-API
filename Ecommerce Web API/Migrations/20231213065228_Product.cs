using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Web_API.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_categoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "productCategoryCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_productCategoryCategoryId",
                table: "Products",
                column: "productCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_productCategoryCategoryId",
                table: "Products",
                column: "productCategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_productCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_productCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "productCategoryCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
