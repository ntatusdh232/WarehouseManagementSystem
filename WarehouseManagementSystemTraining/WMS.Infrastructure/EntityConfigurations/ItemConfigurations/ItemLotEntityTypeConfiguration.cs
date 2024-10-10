namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemLotEntityTypeConfiguration : IEntityTypeConfiguration<ItemLot>
    {
        public void Configure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.HasKey(t => t.LotId);

            // One-to-One relationship with Item
            builder.HasOne(t => t.Item)
                   .WithOne()
                   .HasForeignKey<ItemLot>(t => t.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ Many-to-Many với Location
            builder.HasMany(f => f.Locations)
                   .WithMany(l => l.ItemLots)
                   .UsingEntity(j => j.ToTable("LotLocations"));




        }
    }
}
