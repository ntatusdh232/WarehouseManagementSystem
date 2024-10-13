using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class Finished4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsSublot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "locations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptSublotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptSublotId",
                principalTable: "goodsReceiptsLot",
                principalColumn: "GoodsReceiptLotId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptSublotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "locations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsSublot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptLotId",
                principalTable: "goodsReceiptsLot",
                principalColumn: "GoodsReceiptLotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
