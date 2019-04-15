using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManager.Migrations
{
    public partial class Approved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OApproved",
                table: "ORDERS",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OApproved",
                table: "ORDERS");
        }
    }
}
