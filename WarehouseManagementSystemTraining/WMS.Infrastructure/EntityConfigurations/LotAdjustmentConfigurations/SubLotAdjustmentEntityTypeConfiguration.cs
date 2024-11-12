namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class SubLotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<SublotAdjustment>
    {
        public void Configure(EntityTypeBuilder<SublotAdjustment> builder)
        {
            builder.HasNoKey();
        }

    }
}
