using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace WMS.Infrastructure.EntityConfigurations.ItemLotLocationConfigurations
{
    public class ItemLotLocationEntityTypeConfiguration : IEntityTypeConfiguration<ItemLotLocation>
    {
        public void Configure(EntityTypeBuilder<ItemLotLocation> builder)
        {
            builder.HasKey(l => l.ItemLotLocationId);

            builder.Ignore(l => l.Id);

            builder.HasOne(l => l.ItemLot)
                   .WithMany(s => s.ItemLotLocations)
                   .HasForeignKey(l => l.LotId)
                   .IsRequired(false);

            builder.HasOne(l => l.Location)
                   .WithMany(s => s.ItemLotLocations)
                   .HasForeignKey(l => l.LocationId)
                   .IsRequired(false);


        }



    }
}
