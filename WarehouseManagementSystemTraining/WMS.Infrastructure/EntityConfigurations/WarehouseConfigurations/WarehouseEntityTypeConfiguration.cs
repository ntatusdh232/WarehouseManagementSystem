using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.EntityConfigurations.WarehouseConfigurations
{
    public class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(w => w.WarehouseId);

            builder.HasMany(w => w.Locations)
                   .WithOne()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
