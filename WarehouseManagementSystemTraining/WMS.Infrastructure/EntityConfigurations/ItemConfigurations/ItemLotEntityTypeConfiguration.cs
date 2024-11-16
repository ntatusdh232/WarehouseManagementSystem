namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemLotEntityTypeConfiguration : IEntityTypeConfiguration<ItemLot>
    {
        public void Configure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.HasKey(t => t.LotId);

            builder.Ignore(s => s.Id);

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(t => t.ItemId)
                   .IsRequired(false);

            builder.HasMany(f => f.Locations)
                   .WithMany(l => l.ItemLots)
                   .UsingEntity(j => j.ToTable("LotLocations"));




        }
    }
}
