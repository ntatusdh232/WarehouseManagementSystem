namespace WMS.Infrastructure.EntityConfigurations.InventoryLogEntryConfigurations
{
    public class InventoryLogEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryLogEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryLogEntry> builder)
        {
            builder.HasKey(t => t.ItemLotId);
            // One-to-Many relationship with Item
            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);
        }
    }
}
