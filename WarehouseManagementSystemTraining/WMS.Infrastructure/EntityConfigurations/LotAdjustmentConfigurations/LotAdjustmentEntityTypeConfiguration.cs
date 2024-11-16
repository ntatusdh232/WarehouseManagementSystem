namespace WMS.Infrastructure.EntityConfigurations.LotAdjustmentConfigurations
{
    public class LotAdjustmentEntityTypeConfiguration : IEntityTypeConfiguration<LotAdjustment>
    {
        public void Configure(EntityTypeBuilder<LotAdjustment> builder)
        {
            builder.HasKey(l => l.LotId);

            builder.Ignore(l => l.Id);

            builder.HasOne(l => l.Employee)
                   .WithMany()
                   .HasForeignKey(l => l.EmployeeId)
                   .IsRequired(false);

            builder.HasOne(f => f.Item)
                   .WithMany()
                   .HasForeignKey(f => f.ItemId)
                   .IsRequired(false);
        }
    }
}
