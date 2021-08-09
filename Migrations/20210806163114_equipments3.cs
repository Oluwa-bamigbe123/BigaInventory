using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBetBiga.Migrations
{
    public partial class equipments3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                table: "ManagerEquipmentDistribution",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentsId",
                table: "ManagerEquipmentDistribution",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ManagerEquipmentDistribution_Equipments_EquipmentsId",
                table: "ManagerEquipmentDistribution",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
