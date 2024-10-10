namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceiptEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceiptEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductReceiptEntryId);
            // One-to-One relationship with Item
            builder.HasOne(t => t.Item)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductReceiptEntry>(t => t.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
