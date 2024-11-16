namespace WMS.Infrastructure.EntityConfigurations.LocationConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.LocationId);

            builder.Ignore(l => l.Id);

            builder.HasOne(l => l.Warehouse)
                   .WithMany(s => s.Locations)
                   .HasForeignKey(l => l.WarehouseId)
                   .IsRequired(false);

        }

    }
}
