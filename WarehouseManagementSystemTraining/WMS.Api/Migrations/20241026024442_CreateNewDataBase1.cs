using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDataBase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass");

            migrationBuilder.RenameColumn(
                name: "Itemid",
                table: "itemsClass",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_itemsClass_Itemid",
                table: "itemsClass",
                newName: "IX_itemsClass_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "ItemClassId",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_itemsClass_items_ItemId",
                table: "itemsClass",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemsClass_items_ItemId",
                table: "itemsClass");

            migrationBuilder.DropColumn(
                name: "ItemClassId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "itemsClass",
                newName: "Itemid");

            migrationBuilder.RenameIndex(
                name: "IX_itemsClass_ItemId",
                table: "itemsClass",
                newName: "IX_itemsClass_Itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass",
                column: "Itemid",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
