using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoodsReceiptAggregateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesSublot_goodsIssuesLot_GoodsIssueLotId",
                table: "goodsIssuesSublot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_goodsReceipts_GoodsReceiptId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "goodsReceipts");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueLotId",
                table: "goodsIssuesSublot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesSublot_goodsIssuesLot_GoodsIssueLotId",
                table: "goodsIssuesSublot",
                column: "GoodsIssueLotId",
                principalTable: "goodsIssuesLot",
                principalColumn: "GoodsIssueLotId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_goodsReceipts_GoodsReceiptId",
                table: "goodsReceiptsLot",
                column: "GoodsReceiptId",
                principalTable: "goodsReceipts",
                principalColumn: "GoodsReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesSublot_goodsIssuesLot_GoodsIssueLotId",
                table: "goodsIssuesSublot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_goodsReceipts_GoodsReceiptId",
                table: "goodsReceiptsLot");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "goodsReceipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueLotId",
                table: "goodsIssuesSublot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesSublot_goodsIssuesLot_GoodsIssueLotId",
                table: "goodsIssuesSublot",
                column: "GoodsIssueLotId",
                principalTable: "goodsIssuesLot",
                principalColumn: "GoodsIssueLotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_goodsReceipts_GoodsReceiptId",
                table: "goodsReceiptsLot",
                column: "GoodsReceiptId",
                principalTable: "goodsReceipts",
                principalColumn: "GoodsReceiptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
