using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoodsIssueAggregateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesEntry_goodsIssues_GoodsIssueId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesLot_goodsIssuesEntry_GoodsIssueEntryId",
                table: "goodsIssuesLot");

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
                name: "FK_goodsIssuesEntry_goodsIssues_GoodsIssueId",
                table: "goodsIssuesEntry",
                column: "GoodsIssueId",
                principalTable: "goodsIssues",
                principalColumn: "GoodsIssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesLot_goodsIssuesEntry_GoodsIssueEntryId",
                table: "goodsIssuesLot",
                column: "GoodsIssueEntryId",
                principalTable: "goodsIssuesEntry",
                principalColumn: "GoodsIssueEntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesEntry_goodsIssues_GoodsIssueId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesLot_goodsIssuesEntry_GoodsIssueEntryId",
                table: "goodsIssuesLot");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueLotId",
                table: "goodsIssuesSublot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesEntry_goodsIssues_GoodsIssueId",
                table: "goodsIssuesEntry",
                column: "GoodsIssueId",
                principalTable: "goodsIssues",
                principalColumn: "GoodsIssueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesLot_goodsIssuesEntry_GoodsIssueEntryId",
                table: "goodsIssuesLot",
                column: "GoodsIssueEntryId",
                principalTable: "goodsIssuesEntry",
                principalColumn: "GoodsIssueEntryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
