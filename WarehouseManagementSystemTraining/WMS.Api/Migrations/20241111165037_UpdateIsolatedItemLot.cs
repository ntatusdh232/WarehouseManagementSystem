using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIsolatedItemLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "isolatedItemLots",
                columns: table => new
                {
                    ItemLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isolatedItemLots", x => x.ItemLotId);
                    table.ForeignKey(
                        name: "FK_isolatedItemLots_items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_isolatedItemLots_ItemId1",
                table: "isolatedItemLots",
                column: "ItemId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "isolatedItemLots");
        }
    }
}
