namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemLotEntityTypeConfiguration : IEntityTypeConfiguration<ItemLot>
    {
        public void Configure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.HasKey(t => t.LotId);

            builder.HasOne(t => t.Item)
                   .WithOne()
                   .HasForeignKey<ItemLot>(t => t.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Locations)
                   .WithMany(t => t.ItemLots)
                   .UsingEntity(t => t.ToTable("LotLocations"));




        }
    }
}
