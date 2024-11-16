namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class SubLotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<SublotAdjustment>
    {
        public void Configure(EntityTypeBuilder<SublotAdjustment> builder)
        {
            builder.HasKey(s => s.SublotAdjustmentId);

            builder.HasOne(l => l.LotAdjustment)
                   .WithMany(s => s.SublotAdjustments)
                   .HasForeignKey(l => l.LotAdjustmentId)
                   .IsRequired(false);
        }

    }
}
