namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueLotEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueLot>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLot> builder)
        {
            builder.HasKey(g => g.GoodsIssueLotId);

            builder.HasOne(g => g.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<GoodsIssueLot>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey(g => g.GoodsIssueLotId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
