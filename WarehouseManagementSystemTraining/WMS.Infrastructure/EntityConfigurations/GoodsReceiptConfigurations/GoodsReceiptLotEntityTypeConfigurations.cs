namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptLotEntityTypeConfigurations : IEntityTypeConfiguration<GoodsReceiptLot>
    {
        public void Configure(EntityTypeBuilder<GoodsReceiptLot> builder)
        {
            builder.HasKey(g => g.GoodsReceiptLotId);

            // Cấu hình mối quan hệ One-to-One với Employee
            builder.HasOne(g => g.Employee)
                   .WithOne(e => e.GoodsReceiptLot)
                   .IsRequired()
                   .HasForeignKey<GoodsReceiptLot>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-One với Item
            builder.HasOne(g => g.Item)
                   .WithOne(i => i.GoodsReceiptLot)
                   .IsRequired()
                   .HasForeignKey<GoodsReceiptLot>(g => g.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-Many với GoodsReceiptSubLot
            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsReceiptLotId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
