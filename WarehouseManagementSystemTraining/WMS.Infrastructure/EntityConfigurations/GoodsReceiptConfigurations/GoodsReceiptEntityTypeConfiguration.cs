namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptEntityTypeConfiguration : IEntityTypeConfiguration<GoodsReceipt>
    {
        public void Configure(EntityTypeBuilder<GoodsReceipt> builder)
        {
            builder.HasKey(g => g.GoodsReceiptId); // Sửa lỗi chính tả ở đây

            // Cấu hình mối quan hệ One-to-Many với Employee
            builder.HasOne(g => g.Employee)
                   .WithOne()
                   .HasForeignKey<GoodsReceipt>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-Many với GoodsReceiptEntry
            builder.HasMany(g => g.Lots)
                   .WithOne()
                   .HasForeignKey("GoodsReceiptId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
