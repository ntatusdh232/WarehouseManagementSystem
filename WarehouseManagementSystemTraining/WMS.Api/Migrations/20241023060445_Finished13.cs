using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class Finished13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_lotAdjustments_EmployeeId",
                table: "lotAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_lotAdjustments_ItemId",
                table: "lotAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot");

            migrationBuilder.DropIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseId",
                table: "locations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Itemid",
                table: "itemsClass",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsReceiptId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueLotId",
                table: "goodsIssuesSublot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueEntryId",
                table: "goodsIssuesLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueId",
                table: "goodsIssuesEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_EmployeeId",
                table: "lotAdjustments",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_ItemId",
                table: "lotAdjustments",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_lotAdjustments_EmployeeId",
                table: "lotAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_lotAdjustments_ItemId",
                table: "lotAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot");

            migrationBuilder.DropIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues");

            migrationBuilder.DropIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "warehouses");

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
                name: "Itemid",
                table: "itemsClass",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "GoodsReceiptId",
                table: "goodsReceiptsLot",
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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueEntryId",
                table: "goodsIssuesLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoodsIssueId",
                table: "goodsIssuesEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_EmployeeId",
                table: "lotAdjustments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_ItemId",
                table: "lotAdjustments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories",
                column: "ItemId");
        }
    }
}
