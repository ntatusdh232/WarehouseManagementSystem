namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueLotEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueLot>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLot> builder)
        {
            builder.HasKey(g => g.GoodsIssueLotId);

            // Cấu hình mối quan hệ One-to-One với Employee
            builder.HasOne(g => g.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<GoodsIssueLot>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-Many với GoodsIssueSubLot
            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsIssueLotId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
