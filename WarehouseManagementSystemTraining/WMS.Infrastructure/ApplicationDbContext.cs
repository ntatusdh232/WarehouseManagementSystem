using WMS.Domain.AggregateModels.LocationAggregate;
using WMS.Domain.AggregateModels.WarehouseAggregate;
using WMS.Infrastructure.EntityConfigurations.WarehouseConfigurations;

namespace WMS.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<FinishedProductInventory> finishedProductInventories { get; set; }
        public DbSet<FinishedProductIssue> finishedProductIssues { get; set; }
        public DbSet<FinishedProductIssueEntry> finishedProductIssuesEntry { get; set; }
        public DbSet<FinishedProductReceipt> finishedProductReceipts { get; set; }
        public DbSet<FinishedProductReceiptEntry> finishedProductReceiptsEntry { get; set; }

        public DbSet<GoodsIssue> goodsIssues { get; set; }
        public DbSet<GoodsIssueEntry> goodsIssuesEntry { get; set; }
        public DbSet<GoodsIssueLot> goodsIssuesLot { get; set; }    
        public DbSet<GoodsIssueSublot> goodsIssuesSublot { get; set; } 

        public DbSet<GoodsReceipt> goodsReceipts { get; set; }
        public DbSet<GoodsReceiptLot> goodsReceiptsLot { get; set; }
        public DbSet<GoodsReceiptSublot> goodsReceiptsSublot { get; set; }  

        public DbSet<InventoryLogEntry> inventoryLogEntries { get; set; }

        public DbSet<Item> items { get; set; }  
        public DbSet<ItemClass> itemsClass { get; set; }    
        public DbSet<ItemLot> itemsLot { get; set; }

        public DbSet<Location> locations { get; set; }

        public DbSet<LotAdjustment> lotAdjustments { get; set; }

        public DbSet<Warehouse> warehouses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("items");

            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new FinishedProductInventoryEntryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinishedProductIssueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinishedProductIssueEntryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinishedProductReceiptEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinishedProductReceiptEntryEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new GoodsIssueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsIssueEntryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsIssueLotEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new GoodsReceiptEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsReceiptLotEntityTypeConfigurations());

            modelBuilder.ApplyConfiguration(new InventoryLogEntryEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ItemCLassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemLotEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LotAdjustmentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
