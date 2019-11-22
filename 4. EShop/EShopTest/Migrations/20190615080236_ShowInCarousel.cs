using Microsoft.EntityFrameworkCore.Migrations;

namespace EShopTest.Migrations
{
    public partial class ShowInCarousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInCarousel",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInCarousel",
                table: "Products");
        }
    }
}
