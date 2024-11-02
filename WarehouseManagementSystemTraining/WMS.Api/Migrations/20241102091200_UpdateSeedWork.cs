using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_warehouses_DepartmentWarehouseId",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "DepartmentWarehouseId",
                table: "locations",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_locations_DepartmentWarehouseId",
                table: "locations",
                newName: "IX_locations_WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_warehouses_WarehouseId",
                table: "locations",
                column: "WarehouseId",
                principalTable: "warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_warehouses_WarehouseId",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "locations",
                newName: "DepartmentWarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_locations_WarehouseId",
                table: "locations",
                newName: "IX_locations_DepartmentWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_warehouses_DepartmentWarehouseId",
                table: "locations",
                column: "DepartmentWarehouseId",
                principalTable: "warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
