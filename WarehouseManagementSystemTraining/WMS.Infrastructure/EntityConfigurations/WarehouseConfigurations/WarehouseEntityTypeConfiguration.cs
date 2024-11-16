using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.EntityConfigurations.WarehouseConfigurations
{
    public class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.WarehouseId);

        }
    }
}
