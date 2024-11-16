namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueEntry>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueEntry> builder)
        {
            builder.HasKey(f => f.GoodsIssueEntryId);

            builder.HasOne(f => f.Item)
                   .WithMany()
                   .HasForeignKey(f => f.ItemId)
                   .IsRequired(false);

            builder.HasOne(f => f.GoodsIssue)
                   .WithMany(s => s.Entries)
                   .HasForeignKey(f => f.GoodsIssueId)
                   .IsRequired(false);

        }
    }
}
