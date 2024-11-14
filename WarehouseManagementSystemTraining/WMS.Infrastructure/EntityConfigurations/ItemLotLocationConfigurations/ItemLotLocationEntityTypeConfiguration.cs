using WMS.Domain.AggregateModels.ItemLotLocationAggregate;

namespace WMS.Infrastructure.EntityConfigurations.ItemLotLocationConfigurations
{
    public class ItemLotLocationEntityTypeConfiguration : IEntityTypeConfiguration<ItemLotLocation>
    {
        public void Configure(EntityTypeBuilder<ItemLotLocation> builder)
        {
            builder.HasKey(l => l.ItemLotId);




        }



    }
}
