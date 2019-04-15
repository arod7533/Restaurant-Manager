using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManager.Migrations
{
    public partial class Approved1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "OApproved",
                table: "ORDERS",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OApproved",
                table: "ORDERS",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
