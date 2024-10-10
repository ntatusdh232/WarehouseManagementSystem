namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);

            // Cấu hình mối quan hệ One-to-One với Employee
            builder.HasOne(l => l.Employee)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(l => l.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-One với Item
            builder.HasOne(f => f.Item)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(l => l.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
