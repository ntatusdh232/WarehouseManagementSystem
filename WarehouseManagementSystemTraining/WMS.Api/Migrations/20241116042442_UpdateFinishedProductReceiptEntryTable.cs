using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinishedProductReceiptEntryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceiptsEntry_finishedProductReceipts_FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.DropColumn(
                name: "FinishedProductReceiptEntryId",
                table: "finishedProductReceipts");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceiptsEntry_finishedProductReceipts_FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry",
                column: "FinishedProductReceiptId",
                principalTable: "finishedProductReceipts",
                principalColumn: "FinishedProductReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceiptsEntry_finishedProductReceipts_FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.AddColumn<string>(
                name: "FinishedProductReceiptEntryId",
                table: "finishedProductReceipts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceiptsEntry_finishedProductReceipts_FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry",
                column: "FinishedProductReceiptId",
                principalTable: "finishedProductReceipts",
                principalColumn: "FinishedProductReceiptId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
