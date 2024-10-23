namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);

            builder.HasOne(l => l.Employee)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(g => g.EmployeeId)
                   .IsRequired(false);

            builder.HasOne(f => f.Item)
                   .WithOne()
                   .HasForeignKey<LotAdjustment>(g => g.ItemId)
                   .IsRequired(false);
        }
    }
}
