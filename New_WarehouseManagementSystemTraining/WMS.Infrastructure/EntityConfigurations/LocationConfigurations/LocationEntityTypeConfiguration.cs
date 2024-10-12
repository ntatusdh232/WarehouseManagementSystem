using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.AggregateModels.LocationAggregate;

namespace WMS.Infrastructure.EntityConfigurations.LocationConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.LocationId);

            builder.HasMany(l => l.ItemLots)
                   .WithMany(l => l.Locations)
                   .UsingEntity(l => l.ToTable("LotLocations")); // quan he nhieu nhieu giua ItemLot va Location can bảng trung gian


        }

    }
}
