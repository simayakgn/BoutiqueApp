using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Products_ProductsId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_ProductsId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Wishlists");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Products_ProductId",
                table: "Wishlists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Products_ProductId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Wishlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductsId",
                table: "Wishlists",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Products_ProductsId",
                table: "Wishlists",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
