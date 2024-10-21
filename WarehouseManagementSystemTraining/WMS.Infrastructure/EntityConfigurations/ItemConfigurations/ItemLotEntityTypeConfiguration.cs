namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemLotEntityTypeConfiguration : IEntityTypeConfiguration<ItemLot>
    {
        public void Configure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.HasKey(t => t.LotId);

            // One-to-Many relationship with Item
            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(g => g.ItemId)
                   .IsRequired(false);


            // Cấu hình mối quan hệ Many-to-Many với Location
            builder.HasMany(f => f.Locations)
                   .WithMany(l => l.ItemLots)
                   .UsingEntity(j => j.ToTable("LotLocations"));




        }
    }
}
