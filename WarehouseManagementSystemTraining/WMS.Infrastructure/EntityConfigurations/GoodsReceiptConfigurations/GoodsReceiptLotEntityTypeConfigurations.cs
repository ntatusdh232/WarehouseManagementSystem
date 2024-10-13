namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptLotEntityTypeConfigurations : IEntityTypeConfiguration<GoodsReceiptLot>
    {
        public void Configure(EntityTypeBuilder<GoodsReceiptLot> builder)
        {
            builder.HasKey(g => g.GoodsReceiptLotId);

            builder.HasOne(g => g.Employee)
                   .WithOne(g => g.GoodsReceiptLot)
                   .IsRequired()
                   .HasForeignKey<GoodsReceiptLot>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Item)
                   .WithOne(g => g.GoodsReceiptLot)
                   .IsRequired()
                   .HasForeignKey<GoodsReceiptLot>(g => g.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey(g => g.GoodsReceiptSublotId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
