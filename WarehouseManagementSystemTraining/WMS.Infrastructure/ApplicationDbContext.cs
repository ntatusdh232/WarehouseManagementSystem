using MediatR;
using WMS.Domain.AggregateModels.DepartmentAggregate;
using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;
using WMS.Domain.AggregateModels.StorageAggregate;
using WMS.Infrastructure.EntityConfigurations.DepartmentConfigurations;
using WMS.Infrastructure.EntityConfigurations.IsolatedItemLotConfigurations;

namespace WMS.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public ApplicationDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

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
        public DbSet<IsolatedItemLot> isolatedItemLots { get; set; }

        public DbSet<Location> locations { get; set; }

        public DbSet<LotAdjustment> lotAdjustments { get; set; }
        public DbSet<SublotAdjustment> sublotAdjustments { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }

        public DbSet<Warehouse> warehouses { get; set; }

        public DbSet<Department> departments {  get; set; }
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
            modelBuilder.ApplyConfiguration(new IsolatedItemLotEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LotAdjustmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubLotAdjustmentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }


        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            if (Database.CurrentTransaction != null)
            {
                await Database.CurrentTransaction.CommitAsync(); // Chỉ commit nếu có transaction
            }
            else
            {
                throw new InvalidOperationException("Không có transaction nào được khởi tạo.");
            }
        }


        public void RollbackTransaction()
        {
            if (Database.CurrentTransaction != null)
            {
                Database.CurrentTransaction.Rollback();
            }
            else
            {
                throw new InvalidOperationException("Rollback success");
            }

        }



    }
}
