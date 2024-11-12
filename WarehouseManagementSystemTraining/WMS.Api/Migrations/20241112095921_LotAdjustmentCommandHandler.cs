using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class LotAdjustmentCommandHandler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "lotAdjustments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "lotAdjustments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "sublotAdjustments",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeforeQuantityPerLocation = table.Column<double>(type: "float", nullable: false),
                    AfterQuantityPerLocation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sublotAdjustments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "lotAdjustments");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "lotAdjustments");
        }
    }
}
