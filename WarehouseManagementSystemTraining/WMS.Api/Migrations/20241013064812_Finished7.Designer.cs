﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMS.Infrastructure;

#nullable disable

namespace WMS.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241013064812_Finished7")]
    partial class Finished7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemLotLocation", b =>
                {
                    b.Property<string>("ItemLotsLotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationsLocationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemLotsLotId", "LocationsLocationId");

                    b.HasIndex("LocationsLocationId");

                    b.ToTable("LotLocations", (string)null);
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductInventory", b =>
                {
                    b.Property<string>("FinishedProductInventoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PurchaseOrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FinishedProductInventoryId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("finishedProductInventories");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssue", b =>
                {
                    b.Property<string>("FinishedProductIssueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FinishedProductIssueId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("finishedProductIssues");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssueEntry", b =>
                {
                    b.Property<string>("FinishedProductIssueEntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FinishedProductIssueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaseOrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("FinishedProductIssueEntryId");

                    b.HasIndex("FinishedProductIssueId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("finishedProductIssuesEntry");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceipt", b =>
                {
                    b.Property<string>("FinishedProductReceiptId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FinishedProductReceiptId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("finishedProductReceipts");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceiptEntry", b =>
                {
                    b.Property<string>("FinishedProductReceiptEntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FinishedProductReceiptId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaseOrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("FinishedProductReceiptEntryId");

                    b.HasIndex("FinishedProductReceiptId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("finishedProductReceiptsEntry");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssue", b =>
                {
                    b.Property<string>("GoodsIssueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("GoodsIssueId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("goodsIssues");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueEntry", b =>
                {
                    b.Property<string>("GoodsIssueEntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoodsIssueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("RequestedQuantity")
                        .HasColumnType("float");

                    b.HasKey("GoodsIssueEntryId");

                    b.HasIndex("GoodsIssueId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("goodsIssuesEntry");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueLot", b =>
                {
                    b.Property<string>("GoodsIssueLotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoodsIssueEntryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("GoodsIssueLotId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("GoodsIssueEntryId");

                    b.ToTable("goodsIssuesLot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueSublot", b =>
                {
                    b.Property<string>("GoodsIssueSublotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoodsIssueLotId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QuantityPerLocation")
                        .HasColumnType("float");

                    b.HasKey("GoodsIssueSublotId");

                    b.HasIndex("GoodsIssueLotId");

                    b.ToTable("goodsIssuesSublot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceipt", b =>
                {
                    b.Property<string>("GoodsReceiptId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("GoodsReceiptId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("goodsReceipts");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", b =>
                {
                    b.Property<string>("GoodsReceiptLotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoodsReceiptId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("GoodsReceiptLotId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("GoodsReceiptId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("ItemId1")
                        .IsUnique()
                        .HasFilter("[ItemId1] IS NOT NULL");

                    b.ToTable("goodsReceiptsLot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptSublot", b =>
                {
                    b.Property<string>("GoodsReceiptSublotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoodsReceiptLotId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QuantityPerLocation")
                        .HasColumnType("float");

                    b.HasKey("GoodsReceiptSublotId");

                    b.ToTable("goodsReceiptsSublot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.InventoryLogEntryAggregate.InventoryLogEntry", b =>
                {
                    b.Property<string>("ItemLotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("BeforeQuantity")
                        .HasColumnType("float");

                    b.Property<double>("ChangedQuantity")
                        .HasColumnType("float");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ReceivedQuantity")
                        .HasColumnType("float");

                    b.Property<double>("ShippedQuantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrackingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemLotId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("inventoryLogEntries");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.Item", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MinimumStockLevel")
                        .HasColumnType("float");

                    b.Property<double?>("PacketSize")
                        .HasColumnType("float");

                    b.Property<string>("PacketUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.ItemClass", b =>
                {
                    b.Property<string>("ItemClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Itemid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemClassId");

                    b.HasIndex("Itemid");

                    b.ToTable("itemsClass");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.ItemLot", b =>
                {
                    b.Property<string>("LotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsIsolated")
                        .HasColumnType("bit");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("LotId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("itemsLot");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.LocationAggregate.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WarehouseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LocationId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.LotAdjustmentAggregate.LotAdjustment", b =>
                {
                    b.Property<string>("LotId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("AfterQuantity")
                        .HasColumnType("float");

                    b.Property<double>("BeforeQuantity")
                        .HasColumnType("float");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LotId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("lotAdjustments");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.WarehouseAggregate.Warehouse", b =>
                {
                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("warehouses");
                });

            modelBuilder.Entity("ItemLotLocation", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.ItemLot", null)
                        .WithMany()
                        .HasForeignKey("ItemLotsLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.LocationAggregate.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationsLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductInventory", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductInventory", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssue", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssue", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssueEntry", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssue", null)
                        .WithMany("Entries")
                        .HasForeignKey("FinishedProductIssueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssueEntry", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceipt", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceipt", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceiptEntry", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceipt", null)
                        .WithMany("Entries")
                        .HasForeignKey("FinishedProductReceiptId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceiptEntry", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssue", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssue", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueEntry", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssue", null)
                        .WithMany("Entries")
                        .HasForeignKey("GoodsIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueEntry", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueLot", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueEntry", null)
                        .WithMany("Lots")
                        .HasForeignKey("GoodsIssueEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueSublot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueLot", null)
                        .WithMany("Sublots")
                        .HasForeignKey("GoodsIssueLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceipt", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceipt", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne("GoodsReceiptLot")
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceipt", null)
                        .WithMany("Lots")
                        .HasForeignKey("GoodsReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", null)
                        .WithOne("GoodsReceiptLot")
                        .HasForeignKey("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", "ItemId1");

                    b.Navigation("Employee");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptSublot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", null)
                        .WithMany("Sublots")
                        .HasForeignKey("GoodsReceiptSublotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.InventoryLogEntryAggregate.InventoryLogEntry", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.InventoryLogEntryAggregate.InventoryLogEntry", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.ItemClass", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithMany("ItemClasses")
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.ItemLot", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.ItemAggregate.ItemLot", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.LocationAggregate.Location", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.WarehouseAggregate.Warehouse", null)
                        .WithMany("Locations")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.LotAdjustmentAggregate.LotAdjustment", b =>
                {
                    b.HasOne("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", "Employee")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.LotAdjustmentAggregate.LotAdjustment", "EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WMS.Domain.AggregateModels.ItemAggregate.Item", "Item")
                        .WithOne()
                        .HasForeignKey("WMS.Domain.AggregateModels.LotAdjustmentAggregate.LotAdjustment", "ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.EmployeeAggregate.Employee", b =>
                {
                    b.Navigation("GoodsReceiptLot")
                        .IsRequired();
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductIssue", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.FinishedProductAggregate.FinishedProductReceipt", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssue", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueEntry", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsIssueAggregate.GoodsIssueLot", b =>
                {
                    b.Navigation("Sublots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceipt", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.GoodsReceiptAggregate.GoodsReceiptLot", b =>
                {
                    b.Navigation("Sublots");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.ItemAggregate.Item", b =>
                {
                    b.Navigation("GoodsReceiptLot")
                        .IsRequired();

                    b.Navigation("ItemClasses");
                });

            modelBuilder.Entity("WMS.Domain.AggregateModels.WarehouseAggregate.Warehouse", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
