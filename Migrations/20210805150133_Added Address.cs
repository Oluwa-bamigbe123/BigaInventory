using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBetBiga.Migrations
{
    public partial class AddedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopAddress",
                table: "ManagerEquipmentDistribution",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopAddress",
                table: "ManagerEquipmentDistribution");
        }
    }
}
