namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(t => t.ItemId);
            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18, 2)");

            builder.HasMany(s => s.ItemClasses)
                   .WithOne()
                   .IsRequired(false);

        }
    }
}
