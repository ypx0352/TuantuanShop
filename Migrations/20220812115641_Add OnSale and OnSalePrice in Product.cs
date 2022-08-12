using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuantuanShop.Migrations
{
    public partial class AddOnSaleandOnSalePriceinProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnSale",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OnSalePrice",
                table: "Products",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnSale",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OnSalePrice",
                table: "Products");
        }
    }
}
