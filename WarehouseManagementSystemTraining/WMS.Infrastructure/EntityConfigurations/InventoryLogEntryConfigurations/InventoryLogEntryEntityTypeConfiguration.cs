namespace WMS.Infrastructure.EntityConfigurations.InventoryLogEntryConfigurations
{
    public class InventoryLogEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryLogEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryLogEntry> builder)
        {
            builder.HasKey(t => t.ItemLotId);

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .IsRequired(false);
        }
    }
}
