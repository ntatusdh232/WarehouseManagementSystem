namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(t => t.ItemId);
            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18, 2)");

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

            builder.HasMany(t => t.ItemClasses)
                   .WithOne(t => t.Item)
                   .HasForeignKey(t => t.Itemid)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
