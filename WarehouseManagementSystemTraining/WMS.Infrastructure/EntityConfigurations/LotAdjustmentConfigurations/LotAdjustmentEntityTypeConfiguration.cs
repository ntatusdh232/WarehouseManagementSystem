namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);

            builder.HasOne(l => l.Employee)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(l => l.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Item)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(l => l.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
