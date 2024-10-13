namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssueEntry>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssueEntry> builder)
        {
            builder.HasKey(t => t.FinishedProductIssueEntryId);

            builder.HasOne(t => t.Item)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductIssueEntry>(t => t.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
