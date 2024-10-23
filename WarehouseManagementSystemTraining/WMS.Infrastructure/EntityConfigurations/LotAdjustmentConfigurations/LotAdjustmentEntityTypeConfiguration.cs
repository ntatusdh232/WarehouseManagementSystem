namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);

            builder.HasOne(l => l.Employee)
                   .WithMany()
                   .IsRequired(false);

            builder.HasOne(f => f.Item)
                   .WithMany()
                   .IsRequired(false);
        }
    }
}
