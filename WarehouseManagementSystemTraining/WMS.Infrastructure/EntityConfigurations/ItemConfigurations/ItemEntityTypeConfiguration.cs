namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(t => t.ItemId);
            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne(s => s.ItemClasses)
                   .WithMany(s => s.Item)
                   .HasForeignKey(s => s.ItemClassId)
                   .IsRequired(false);

        }
    }
}
