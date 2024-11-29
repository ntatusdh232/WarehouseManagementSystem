using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvetoryLogEntryProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inventoryLogEntries",
                table: "inventoryLogEntries");

            migrationBuilder.AlterColumn<string>(
                name: "ItemLotId",
                table: "inventoryLogEntries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "inventoryLogEntries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventoryLogEntries",
                table: "inventoryLogEntries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inventoryLogEntries",
                table: "inventoryLogEntries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "inventoryLogEntries");

            migrationBuilder.AlterColumn<string>(
                name: "ItemLotId",
                table: "inventoryLogEntries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventoryLogEntries",
                table: "inventoryLogEntries",
                column: "ItemLotId");
        }
    }
}
