namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(t => t.ItemId);
            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18, 2)");

            // One-to-One relationships
            builder.HasOne<GoodsIssueEntry>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<LotAdjustment>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<GoodsReceiptLot>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinishedProductIssueEntry>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinishedProductReceiptEntry>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<InventoryLogEntry>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinishedProductInventory>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ItemLot>()
                   .WithOne(t => t.Item)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            // Mối quan hệ một-nhiều với ItemClass
            builder.HasMany(i => i.ItemClasses)
                   .WithOne(ic => ic.Item)
                   .HasForeignKey(ic => ic.Itemid)
                   .OnDelete(DeleteBehavior.Cascade); // Hoặc Restrict nếu bạn muốn bảo vệ không cho xóa

        }
    }
}
