namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueLotEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssueLot>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueLot> builder)
        {
            builder.HasKey(g => g.GoodsIssueLotId);

            // Cấu hình mối quan hệ One-to-Many với Employee
            builder.HasOne(g => g.Employee)
                   .WithMany()
                   .HasForeignKey(g => g.EmployeeId)
                   .IsRequired(false);


            // Cấu hình mối quan hệ One-to-Many với GoodsIssueSubLot
            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsIssueLotId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
