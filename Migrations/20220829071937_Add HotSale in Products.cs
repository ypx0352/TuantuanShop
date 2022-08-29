using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuantuanShop.Migrations
{
    public partial class AddHotSaleinProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HotSale",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotSale",
                table: "Products");
        }
    }
}
