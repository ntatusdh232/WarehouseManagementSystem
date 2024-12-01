using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemClassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemsClass_items_ItemId",
                table: "itemsClass");

            migrationBuilder.DropIndex(
                name: "IX_itemsClass_ItemId",
                table: "itemsClass");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "itemsClass");

            migrationBuilder.AlterColumn<string>(
                name: "ItemClassId",
                table: "items",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemClassId",
                table: "items",
                column: "ItemClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_items_itemsClass_ItemClassId",
                table: "items",
                column: "ItemClassId",
                principalTable: "itemsClass",
                principalColumn: "ItemClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_itemsClass_ItemClassId",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_ItemClassId",
                table: "items");

            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "itemsClass",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemClassId",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemsClass_ItemId",
                table: "itemsClass",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_itemsClass_items_ItemId",
                table: "itemsClass",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");
        }
    }
}
