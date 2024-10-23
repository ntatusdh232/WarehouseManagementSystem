namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueEntryEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueEntry>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueEntry> builder)
        {
            builder.HasKey(f => f.GoodsIssueEntryId);

            builder.HasOne(f => f.Item)
                   .WithOne()
                   .HasForeignKey<GoodsIssueEntry>(g => g.ItemId)
                   .IsRequired(false);

            builder.HasMany(f => f.Lots)
                   .WithOne()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
