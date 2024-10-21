namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssueEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssueEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductIssueEntryId);

            // One-to-Many relationship with Item
            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);
        }
    }
}
