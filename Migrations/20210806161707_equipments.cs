using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBetBiga.Migrations
{
    public partial class equipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentsId",
                table: "ManagerEquipmentDistribution",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagerEquipmentDistribution_EquipmentsId",
                table: "ManagerEquipmentDistribution",
                column: "EquipmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution");

            migrationBuilder.DropIndex(
                name: "IX_ManagerEquipmentDistribution_EquipmentsId",
                table: "ManagerEquipmentDistribution");

            migrationBuilder.DropColumn(
                name: "EquipmentsId",
                table: "ManagerEquipmentDistribution");
        }
    }
}
