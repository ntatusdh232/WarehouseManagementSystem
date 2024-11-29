namespace WMS.Infrastructure.EntityConfigurations.InventoryLogEntryConfigurations
{
    public class InventoryLogEntryEntityTypeConfiguration : IEntityTypeConfiguration<InventoryLogEntry>
    {
        public void Configure(EntityTypeBuilder<InventoryLogEntry> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(t => t.ItemId)
                   .IsRequired(false);
        }
    }
}
