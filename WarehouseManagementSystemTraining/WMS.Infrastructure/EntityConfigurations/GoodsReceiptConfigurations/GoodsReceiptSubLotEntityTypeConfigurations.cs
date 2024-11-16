namespace WMS.Infrastructure.EntityConfigurations.GoodsReceiptConfigurations
{
    public class GoodsReceiptSubLotEntityTypeConfigurations : IEntityTypeConfiguration<GoodsIssueSublot>
    {
        public void Configure(EntityTypeBuilder<GoodsIssueSublot> builder)
        {
            builder.HasKey(g => g.GoodsIssueSublotId);
            
            builder.HasOne(g => g.GoodsIssueLot)
                   .WithMany(s => s.Sublots)
                   .HasForeignKey(g => g.GoodsIssueLotId)
                   .IsRequired(false);

        }
    }
}
