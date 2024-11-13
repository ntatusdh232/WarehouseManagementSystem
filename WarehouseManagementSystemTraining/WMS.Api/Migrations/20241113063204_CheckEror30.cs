using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class CheckEror30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotLocations_locations_LocationsLocationId",
                table: "LotLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LotLocations",
                table: "LotLocations");

            migrationBuilder.DropIndex(
                name: "IX_LotLocations_LocationsLocationId",
                table: "LotLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "LocationsLocationId",
                table: "LotLocations");

            migrationBuilder.AddColumn<int>(
                name: "LocationsId",
                table: "LotLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "locations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionDate",
                table: "itemsLot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "itemsLot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "itemsLot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LotLocations",
                table: "LotLocations",
                columns: new[] { "ItemLotsLotId", "LocationsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemLotLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerLocation = table.Column<double>(type: "float", nullable: false),
                    LocationId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLotLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLotLocation_itemsLot_ItemLotId",
                        column: x => x.ItemLotId,
                        principalTable: "itemsLot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemLotLocation_locations_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotLocations_LocationsId",
                table: "LotLocations",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLotLocation_ItemLotId",
                table: "ItemLotLocation",
                column: "ItemLotId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLotLocation_LocationId1",
                table: "ItemLotLocation",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LotLocations_locations_LocationsId",
                table: "LotLocations",
                column: "LocationsId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotLocations_locations_LocationsId",
                table: "LotLocations");

            migrationBuilder.DropTable(
                name: "ItemLotLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LotLocations",
                table: "LotLocations");

            migrationBuilder.DropIndex(
                name: "IX_LotLocations_LocationsId",
                table: "LotLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locations",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "LocationsId",
                table: "LotLocations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "itemsLot");

            migrationBuilder.AddColumn<string>(
                name: "LocationsLocationId",
                table: "LotLocations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LocationId",
                table: "locations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionDate",
                table: "itemsLot",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "itemsLot",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LotLocations",
                table: "LotLocations",
                columns: new[] { "ItemLotsLotId", "LocationsLocationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_locations",
                table: "locations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LotLocations_LocationsLocationId",
                table: "LotLocations",
                column: "LocationsLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LotLocations_locations_LocationsLocationId",
                table: "LotLocations",
                column: "LocationsLocationId",
                principalTable: "locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
