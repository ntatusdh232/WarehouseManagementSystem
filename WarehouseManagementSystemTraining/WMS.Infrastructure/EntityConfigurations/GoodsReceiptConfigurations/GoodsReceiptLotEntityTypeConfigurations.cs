namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptLotEntityTypeConfigurations : IEntityTypeConfiguration<GoodsReceiptLot>
    {
        public void Configure(EntityTypeBuilder<GoodsReceiptLot> builder)
        {
            builder.HasKey(g => g.GoodsReceiptLotId);

            builder.HasOne(g => g.Employee)
                   .WithMany()
                   .HasForeignKey(g => g.EmployeeId)
                   .IsRequired(false);

            builder.HasOne(g => g.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);

            builder.HasMany(g => g.Sublots)
                   .WithOne()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
