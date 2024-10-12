using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class Finished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumStockLevel = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PacketSize = table.Column<double>(type: "float", nullable: true),
                    PacketUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "finishedProductIssues",
                columns: table => new
                {
                    FinishedProductIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishedProductIssues", x => x.FinishedProductIssueId);
                    table.ForeignKey(
                        name: "FK_finishedProductIssues_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "finishedProductReceipts",
                columns: table => new
                {
                    FinishedProductReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishedProductReceipts", x => x.FinishedProductReceiptId);
                    table.ForeignKey(
                        name: "FK_finishedProductReceipts_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goodsIssues",
                columns: table => new
                {
                    GoodsIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsIssues", x => x.GoodsIssueId);
                    table.ForeignKey(
                        name: "FK_goodsIssues_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goodsReceipts",
                columns: table => new
                {
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsReceipts", x => x.GoodsReceiptId);
                    table.ForeignKey(
                        name: "FK_goodsReceipts_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "finishedProductInventories",
                columns: table => new
                {
                    FinishedProductInventoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishedProductInventories", x => x.FinishedProductInventoryId);
                    table.ForeignKey(
                        name: "FK_finishedProductInventories_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventoryLogEntries",
                columns: table => new
                {
                    ItemLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeforeQuantity = table.Column<double>(type: "float", nullable: false),
                    ChangedQuantity = table.Column<double>(type: "float", nullable: false),
                    ReceivedQuantity = table.Column<double>(type: "float", nullable: false),
                    ShippedQuantity = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryLogEntries", x => x.ItemLotId);
                    table.ForeignKey(
                        name: "FK_inventoryLogEntries_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "itemsClass",
                columns: table => new
                {
                    ItemClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Itemid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsClass", x => x.ItemClassId);
                    table.ForeignKey(
                        name: "FK_itemsClass_items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemsLot",
                columns: table => new
                {
                    LotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsIsolated = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsLot", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_itemsLot_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lotAdjustments",
                columns: table => new
                {
                    LotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeforeQuantity = table.Column<double>(type: "float", nullable: false),
                    AfterQuantity = table.Column<double>(type: "float", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotAdjustments", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_lotAdjustments_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lotAdjustments_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_locations_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "finishedProductIssuesEntry",
                columns: table => new
                {
                    FinishedProductIssueEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FinishedProductIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishedProductIssuesEntry", x => x.FinishedProductIssueEntryId);
                    table.ForeignKey(
                        name: "FK_finishedProductIssuesEntry_finishedProductIssues_FinishedProductIssueId",
                        column: x => x.FinishedProductIssueId,
                        principalTable: "finishedProductIssues",
                        principalColumn: "FinishedProductIssueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_finishedProductIssuesEntry_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "finishedProductReceiptsEntry",
                columns: table => new
                {
                    FinishedProductReceiptEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FinishedProductReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishedProductReceiptsEntry", x => x.FinishedProductReceiptEntryId);
                    table.ForeignKey(
                        name: "FK_finishedProductReceiptsEntry_finishedProductReceipts_FinishedProductReceiptId",
                        column: x => x.FinishedProductReceiptId,
                        principalTable: "finishedProductReceipts",
                        principalColumn: "FinishedProductReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_finishedProductReceiptsEntry_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goodsIssuesEntry",
                columns: table => new
                {
                    GoodsIssueEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestedQuantity = table.Column<double>(type: "float", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsIssueId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsIssuesEntry", x => x.GoodsIssueEntryId);
                    table.ForeignKey(
                        name: "FK_goodsIssuesEntry_goodsIssues_GoodsIssueId",
                        column: x => x.GoodsIssueId,
                        principalTable: "goodsIssues",
                        principalColumn: "GoodsIssueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goodsIssuesEntry_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goodsReceiptsLot",
                columns: table => new
                {
                    GoodsReceiptLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItemId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsReceiptsLot", x => x.GoodsReceiptLotId);
                    table.ForeignKey(
                        name: "FK_goodsReceiptsLot_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goodsReceiptsLot_goodsReceipts_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "goodsReceipts",
                        principalColumn: "GoodsReceiptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goodsReceiptsLot_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goodsReceiptsLot_items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "LotLocations",
                columns: table => new
                {
                    ItemLotsLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationsLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotLocations", x => new { x.ItemLotsLotId, x.LocationsLocationId });
                    table.ForeignKey(
                        name: "FK_LotLocations_itemsLot_ItemLotsLotId",
                        column: x => x.ItemLotsLotId,
                        principalTable: "itemsLot",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotLocations_locations_LocationsLocationId",
                        column: x => x.LocationsLocationId,
                        principalTable: "locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goodsIssuesLot",
                columns: table => new
                {
                    GoodsIssueLotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoodsIssueEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsIssuesLot", x => x.GoodsIssueLotId);
                    table.ForeignKey(
                        name: "FK_goodsIssuesLot_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goodsIssuesLot_goodsIssuesEntry_GoodsIssueEntryId",
                        column: x => x.GoodsIssueEntryId,
                        principalTable: "goodsIssuesEntry",
                        principalColumn: "GoodsIssueEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goodsReceiptsSublot",
                columns: table => new
                {
                    GoodsReceiptSublotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerLocation = table.Column<double>(type: "float", nullable: false),
                    GoodsReceiptLotId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsReceiptsSublot", x => x.GoodsReceiptSublotId);
                    table.ForeignKey(
                        name: "FK_goodsReceiptsSublot_goodsReceiptsLot_GoodsReceiptLotId",
                        column: x => x.GoodsReceiptLotId,
                        principalTable: "goodsReceiptsLot",
                        principalColumn: "GoodsReceiptLotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goodsIssuesSublot",
                columns: table => new
                {
                    GoodsIssueSublotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerLocation = table.Column<double>(type: "float", nullable: false),
                    GoodsIssueLotId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsIssuesSublot", x => x.GoodsIssueSublotId);
                    table.ForeignKey(
                        name: "FK_goodsIssuesSublot_goodsIssuesLot_GoodsIssueLotId",
                        column: x => x.GoodsIssueLotId,
                        principalTable: "goodsIssuesLot",
                        principalColumn: "GoodsIssueLotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductInventories_ItemId",
                table: "finishedProductInventories",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssues_EmployeeId",
                table: "finishedProductIssues",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssuesEntry_FinishedProductIssueId",
                table: "finishedProductIssuesEntry",
                column: "FinishedProductIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductIssuesEntry_ItemId",
                table: "finishedProductIssuesEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceipts_EmployeeId",
                table: "finishedProductReceipts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceiptsEntry_FinishedProductReceiptId",
                table: "finishedProductReceiptsEntry",
                column: "FinishedProductReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_finishedProductReceiptsEntry_ItemId",
                table: "finishedProductReceiptsEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssues_EmployeeId",
                table: "goodsIssues",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesEntry_GoodsIssueId",
                table: "goodsIssuesEntry",
                column: "GoodsIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesEntry_ItemId",
                table: "goodsIssuesEntry",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesLot_EmployeeId",
                table: "goodsIssuesLot",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesLot_GoodsIssueEntryId",
                table: "goodsIssuesLot",
                column: "GoodsIssueEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsIssuesSublot_GoodsIssueLotId",
                table: "goodsIssuesSublot",
                column: "GoodsIssueLotId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceipts_EmployeeId",
                table: "goodsReceipts",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_EmployeeId",
                table: "goodsReceiptsLot",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_GoodsReceiptId",
                table: "goodsReceiptsLot",
                column: "GoodsReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_ItemId",
                table: "goodsReceiptsLot",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsLot_ItemId1",
                table: "goodsReceiptsLot",
                column: "ItemId1",
                unique: true,
                filter: "[ItemId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_goodsReceiptsSublot_GoodsReceiptLotId",
                table: "goodsReceiptsSublot",
                column: "GoodsReceiptLotId");

            migrationBuilder.CreateIndex(
                name: "IX_inventoryLogEntries_ItemId",
                table: "inventoryLogEntries",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemsClass_Itemid",
                table: "itemsClass",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_itemsLot_ItemId",
                table: "itemsLot",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_locations_WarehouseId",
                table: "locations",
                column: "WarehouseId");

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
                name: "IX_LotLocations_LocationsLocationId",
                table: "LotLocations",
                column: "LocationsLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finishedProductInventories");

            migrationBuilder.DropTable(
                name: "finishedProductIssuesEntry");

            migrationBuilder.DropTable(
                name: "finishedProductReceiptsEntry");

            migrationBuilder.DropTable(
                name: "goodsIssuesSublot");

            migrationBuilder.DropTable(
                name: "goodsReceiptsSublot");

            migrationBuilder.DropTable(
                name: "inventoryLogEntries");

            migrationBuilder.DropTable(
                name: "itemsClass");

            migrationBuilder.DropTable(
                name: "lotAdjustments");

            migrationBuilder.DropTable(
                name: "LotLocations");

            migrationBuilder.DropTable(
                name: "finishedProductIssues");

            migrationBuilder.DropTable(
                name: "finishedProductReceipts");

            migrationBuilder.DropTable(
                name: "goodsIssuesLot");

            migrationBuilder.DropTable(
                name: "goodsReceiptsLot");

            migrationBuilder.DropTable(
                name: "itemsLot");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "goodsIssuesEntry");

            migrationBuilder.DropTable(
                name: "goodsReceipts");

            migrationBuilder.DropTable(
                name: "warehouses");

            migrationBuilder.DropTable(
                name: "goodsIssues");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
