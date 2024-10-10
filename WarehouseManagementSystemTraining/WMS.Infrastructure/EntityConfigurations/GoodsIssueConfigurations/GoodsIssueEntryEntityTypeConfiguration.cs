namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueEntry>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueEntry> builder)
        {
            builder.HasKey(f => f.GoodsIssueEntryId);
            // Cấu hình mối quan hệ One-to-One với Item
            builder.HasOne(f => f.Item)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<GoodsIssueEntry>(f => f.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);
            // Cấu hình mối quan hệ One-to-Many với GoodsIssueLot
            builder.HasMany(f => f.Lots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsIssueEntryId")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
