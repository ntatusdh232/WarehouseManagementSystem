using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateErrorNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId1",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_EmployeeId1",
                table: "goodsReceiptsLot");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "goodsReceiptsLot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId1",
                table: "goodsReceiptsLot",
                column: "EmployeeId1",
                unique: true,
                filter: "[EmployeeId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId1",
                table: "goodsReceiptsLot",
                column: "EmployeeId1",
                principalTable: "employees",
                principalColumn: "EmployeeId");
        }
    }
}
