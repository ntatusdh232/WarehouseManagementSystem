using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;

namespace WMS.Infrastructure.EntityConfigurations.IsolatedItemLotConfigurations
{
    public class IsolatedItemLotEntityTypeConfiguration : IEntityTypeConfiguration<IsolatedItemLot>
    {
        public void Configure(EntityTypeBuilder<IsolatedItemLot> builder)
        {
            builder.HasKey(t => t.ItemLotId);

            builder.Ignore(t => t.Id);

            builder.HasOne(t => t.Item)
                   .WithMany()
                   .HasForeignKey(t => t.ItemId)
                   .IsRequired(false);
        }
    }
}
