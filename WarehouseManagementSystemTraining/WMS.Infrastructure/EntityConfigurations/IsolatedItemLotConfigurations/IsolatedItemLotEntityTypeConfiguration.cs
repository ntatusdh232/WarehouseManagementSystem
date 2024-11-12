using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;

namespace WMS.Infrastructure.EntityConfigurations.IsolatedItemLotConfigurations
{
    public class IsolatedItemLotEntityTypeConfiguration : IEntityTypeConfiguration<IsolatedItemLot>
    {
        public void Configure(EntityTypeBuilder<IsolatedItemLot> builder)
        {
            builder.HasKey(t => t.ItemLotId);
        }
    }
}
