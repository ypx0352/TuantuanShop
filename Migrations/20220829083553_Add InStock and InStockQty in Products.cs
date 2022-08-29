using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuantuanShop.Migrations
{
    public partial class AddInStockandInStockQtyinProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutOfStock",
                table: "Products",
                newName: "InStock");

            migrationBuilder.AddColumn<int>(
                name: "InStockQty",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStockQty",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "InStock",
                table: "Products",
                newName: "OutOfStock");
        }
    }
}
