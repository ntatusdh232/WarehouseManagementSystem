namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueLotEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueLot>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLot> builder)
        {
            builder.HasKey(g => g.GoodsIssueLotId);

            builder.HasOne(g => g.Employee)
                   .WithMany()
                   .IsRequired(false);

            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
