using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBetBiga.Migrations
{
    public partial class EquipmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "ManagerEquipmentDistribution",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "ManagerEquipmentDistribution");
        }
    }
}
