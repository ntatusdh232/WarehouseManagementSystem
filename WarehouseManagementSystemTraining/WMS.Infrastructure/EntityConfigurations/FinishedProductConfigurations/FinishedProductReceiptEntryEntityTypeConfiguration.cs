namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceiptEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceiptEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductReceiptEntryId);

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .IsRequired(false);
        }
    }
}
