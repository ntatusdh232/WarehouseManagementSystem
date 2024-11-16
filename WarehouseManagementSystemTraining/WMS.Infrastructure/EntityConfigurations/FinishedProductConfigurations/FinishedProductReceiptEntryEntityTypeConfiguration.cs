namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceiptEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceiptEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductReceiptEntryId);

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(t => t.ItemId)
                   .IsRequired(false);

            builder.HasOne(t => t.FinishedProductReceipt)
                   .WithMany(s => s.Entries)
                   .HasForeignKey(t => t.FinishedProductReceiptId)
                   .IsRequired(false);
        }
    }
}
