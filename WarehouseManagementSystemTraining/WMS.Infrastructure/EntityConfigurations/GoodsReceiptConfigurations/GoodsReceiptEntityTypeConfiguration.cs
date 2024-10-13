namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptEntityTypeConfiguration : IEntityTypeConfiguration<GoodsReceipt>
    {
        public void Configure(EntityTypeBuilder<GoodsReceipt> builder)
        {
            builder.HasKey(g => g.GoodsReceiptId);

            builder.HasOne(g => g.Employee)
                   .WithOne()
                   .HasForeignKey<GoodsReceipt>(g => g.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Lots)
                   .WithOne()
                   .HasForeignKey(g => g.GoodsReceiptId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
