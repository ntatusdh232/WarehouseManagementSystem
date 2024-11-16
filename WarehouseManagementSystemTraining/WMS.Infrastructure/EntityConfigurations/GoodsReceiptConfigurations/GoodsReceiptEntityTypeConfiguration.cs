namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptEntityTypeConfiguration : IEntityTypeConfiguration<GoodsReceipt>
    {
        public void Configure(EntityTypeBuilder<GoodsReceipt> builder)
        {
            builder.HasKey(g => g.GoodsReceiptId);

            builder.Ignore(g => g.Id);

            builder.HasOne(g => g.Employee)
                   .WithMany()
                   .IsRequired(false);
        }
    }
}
