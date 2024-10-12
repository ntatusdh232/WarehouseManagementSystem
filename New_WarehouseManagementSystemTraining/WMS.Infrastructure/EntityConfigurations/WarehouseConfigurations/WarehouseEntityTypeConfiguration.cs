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

            builder.HasMany(w => w.Locations)
                   .WithOne()
                   .HasForeignKey(w => w.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
