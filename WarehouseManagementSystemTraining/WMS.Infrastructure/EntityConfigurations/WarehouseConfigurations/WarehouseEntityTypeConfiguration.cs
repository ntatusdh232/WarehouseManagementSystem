using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.AggregateModels.WarehouseAggregate;

namespace WMS.Infrastructure.EntityConfigurations.WarehouseConfigurations
{
    public class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.WarehouseId);

            // One-to-Many relationship with Location
            builder.HasMany(w => w.Locations)
                   .WithOne()
                   .HasForeignKey("WarehouseId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
