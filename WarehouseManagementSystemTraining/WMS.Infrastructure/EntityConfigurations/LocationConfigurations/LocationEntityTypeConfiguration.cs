namespace WMS.Infrastructure.EntityConfigurations.LocationConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.LocationId);

            builder.HasMany(l => l.ItemLots)
                   .WithMany(l => l.Locations)
                   .UsingEntity(l => l.ToTable("LotLocations")); 


        }

    }
}
