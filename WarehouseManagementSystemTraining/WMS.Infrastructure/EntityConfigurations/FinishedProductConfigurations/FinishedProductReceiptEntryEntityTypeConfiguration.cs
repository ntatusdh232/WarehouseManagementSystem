namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceiptEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceiptEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductReceiptEntryId);

            // One-to-Many relationship with Item
            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);
        }
    }
}
