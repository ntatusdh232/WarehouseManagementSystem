using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDataBase : Migration
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
    }
}
