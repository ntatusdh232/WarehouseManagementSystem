namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);
            // Cấu hình mối quan hệ One-to-Many với Employee
            builder.HasOne(l => l.Employee)
                   .WithMany()
                   .HasForeignKey(g => g.EmployeeId)
                   .IsRequired(false);

            // Cấu hình mối quan hệ One-to-Mamy với Item
            builder.HasOne(f => f.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);
        }
    }
}
