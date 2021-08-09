using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBetBiga.Migrations
{
    public partial class AddedMaanagerUsernametodistribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "AdminEquipmentDistribution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipmentType",
                table: "AdminEquipmentDistribution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerUserName",
                table: "AdminEquipmentDistribution",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "AdminEquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "AdminEquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "ManagerUserName",
                table: "AdminEquipmentDistribution");
        }
    }
}
