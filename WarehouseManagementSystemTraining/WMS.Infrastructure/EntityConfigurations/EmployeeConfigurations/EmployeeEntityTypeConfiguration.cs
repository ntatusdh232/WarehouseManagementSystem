namespace WMS.Infrastructure.EntityConfigurations.EmployeeConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(t => t.EmployeeId);


            builder.HasOne<GoodsIssue>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<GoodsIssue>(t => t.EmployeeId) 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<GoodsIssueLot>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<GoodsIssueLot>(t => t.EmployeeId) 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<GoodsReceipt>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<GoodsReceipt>(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<LotAdjustment>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<LotAdjustment>(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<GoodsReceiptLot>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<GoodsReceiptLot>(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinishedProductIssue>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<FinishedProductIssue>(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinishedProductReceipt>()
                   .WithOne(t => t.Employee)
                   .HasForeignKey<FinishedProductReceipt>(t => t.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
