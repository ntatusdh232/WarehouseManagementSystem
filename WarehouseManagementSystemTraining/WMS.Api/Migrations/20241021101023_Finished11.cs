using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class Finished11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductInventories_items_ItemId",
                table: "finishedProductInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssues_employees_EmployeeId",
                table: "finishedProductIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssuesEntry_items_ItemId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceipts_employees_EmployeeId",
                table: "finishedProductReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceiptsEntry_items_ItemId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssues_employees_EmployeeId",
                table: "goodsIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesEntry_items_ItemId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesLot_employees_EmployeeId",
                table: "goodsIssuesLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceipts_employees_EmployeeId",
                table: "goodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_items_ItemId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptSublotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.DropForeignKey(
                name: "FK_inventoryLogEntries_items_ItemId",
                table: "inventoryLogEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass");

            migrationBuilder.DropForeignKey(
                name: "FK_itemsLot_items_ItemId",
                table: "itemsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_lotAdjustments_employees_EmployeeId",
                table: "lotAdjustments");

            migrationBuilder.DropForeignKey(
                name: "FK_lotAdjustments_items_ItemId",
                table: "lotAdjustments");

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

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "lotAdjustments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "lotAdjustments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "itemsLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "inventoryLogEntries",
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
                name: "ItemId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsReceipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsIssuesLot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "goodsIssuesEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsIssues",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductReceiptsEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "finishedProductReceipts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "finishedProductIssues",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductInventories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "IX_goodsReceiptsSublot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptLotId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId1",
                table: "goodsReceiptsLot",
                column: "EmployeeId1",
                unique: true,
                filter: "[EmployeeId1] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductInventories_items_ItemId",
                table: "finishedProductInventories",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssues_employees_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssuesEntry_items_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceipts_employees_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceiptsEntry_items_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssues_employees_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesEntry_items_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesLot_employees_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceipts_employees_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId1",
                table: "goodsReceiptsLot",
                column: "EmployeeId1",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_items_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptLotId",
                principalTable: "goodsReceiptsLot",
                principalColumn: "GoodsReceiptLotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventoryLogEntries_items_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass",
                column: "Itemid",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_itemsLot_items_ItemId",
                table: "itemsLot",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_lotAdjustments_employees_EmployeeId",
                table: "lotAdjustments",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_lotAdjustments_items_ItemId",
                table: "lotAdjustments",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductInventories_items_ItemId",
                table: "finishedProductInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssues_employees_EmployeeId",
                table: "finishedProductIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductIssuesEntry_items_ItemId",
                table: "finishedProductIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceipts_employees_EmployeeId",
                table: "finishedProductReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_finishedProductReceiptsEntry_items_ItemId",
                table: "finishedProductReceiptsEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssues_employees_EmployeeId",
                table: "goodsIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesEntry_items_ItemId",
                table: "goodsIssuesEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsIssuesLot_employees_EmployeeId",
                table: "goodsIssuesLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceipts_employees_EmployeeId",
                table: "goodsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId1",
                table: "goodsReceiptsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsLot_items_ItemId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.DropForeignKey(
                name: "FK_inventoryLogEntries_items_ItemId",
                table: "inventoryLogEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass");

            migrationBuilder.DropForeignKey(
                name: "FK_itemsLot_items_ItemId",
                table: "itemsLot");

            migrationBuilder.DropForeignKey(
                name: "FK_lotAdjustments_employees_EmployeeId",
                table: "lotAdjustments");

            migrationBuilder.DropForeignKey(
                name: "FK_lotAdjustments_items_ItemId",
                table: "lotAdjustments");

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
                name: "IX_goodsReceiptsSublot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot");

            migrationBuilder.DropIndex(
                name: "IX_goodsReceiptsLot_EmployeeId1",
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
                name: "EmployeeId1",
                table: "goodsReceiptsLot");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "lotAdjustments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "lotAdjustments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "itemsLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "inventoryLogEntries",
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
                name: "ItemId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsReceiptsLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsReceipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsIssuesLot",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "goodsIssuesEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "goodsIssues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductReceiptsEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "finishedProductReceipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductIssuesEntry",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "finishedProductIssues",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "finishedProductInventories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_EmployeeId",
                table: "lotAdjustments",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lotAdjustments_ItemId",
                table: "lotAdjustments",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductInventories_items_ItemId",
                table: "finishedProductInventories",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssues_employees_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductIssuesEntry_items_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceipts_employees_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_finishedProductReceiptsEntry_items_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssues_employees_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesEntry_items_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsIssuesLot_employees_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceipts_employees_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_employees_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsLot_items_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptSublotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptSublotId",
                principalTable: "goodsReceiptsLot",
                principalColumn: "GoodsReceiptLotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventoryLogEntries_items_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_itemsClass_items_Itemid",
                table: "itemsClass",
                column: "Itemid",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_itemsLot_items_ItemId",
                table: "itemsLot",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_lotAdjustments_employees_EmployeeId",
                table: "lotAdjustments",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_lotAdjustments_items_ItemId",
                table: "lotAdjustments",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
