namespace WMS.Infrastructure.EntityConfigurations.InventoryLogEntryConfigurations
{
    public class InventoryLogEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryLogEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryLogEntry> builder)
        {
            builder.HasKey(t => t.ItemLotId);

            // One-to-One relationship with Item
            builder.HasOne(t => t.Item)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<InventoryLogEntry>(t => t.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
