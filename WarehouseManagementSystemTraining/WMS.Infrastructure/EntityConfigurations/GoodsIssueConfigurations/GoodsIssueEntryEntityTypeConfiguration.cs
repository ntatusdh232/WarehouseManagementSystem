namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueEntry>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueEntry> builder)
        {
            builder.HasKey(f => f.GoodsIssueEntryId);

            builder.HasOne(f => f.Item)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<GoodsIssueEntry>(f => f.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Lots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey(f => f.GoodsIssueEntryId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
