namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptLotEntityTypeConfigurations : IEntityTypeConfiguration<GoodsReceiptLot>
    {
        public void Configure(EntityTypeBuilder<GoodsReceiptLot> builder)
        {
            builder.HasKey(g => g.GoodsReceiptLotId);

            // Cấu hình mối quan hệ One-to-Many với Employee
            builder.HasOne(g => g.Employee)
                   .WithMany()
                   .HasForeignKey(g => g.EmployeeId)
                   .IsRequired(false);

            // Cấu hình mối quan hệ One-to-Many với Item
            builder.HasOne(g => g.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);

            // Cấu hình mối quan hệ One-to-Many với GoodsReceiptSubLot
            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsReceiptLotId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
