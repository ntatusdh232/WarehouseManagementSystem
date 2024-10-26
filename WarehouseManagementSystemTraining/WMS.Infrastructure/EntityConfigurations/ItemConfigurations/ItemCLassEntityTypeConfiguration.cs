namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemCLassEntityTypeConfiguration : IEntityTypeConfiguration<ItemClass>
    {
        public void Configure(EntityTypeBuilder<ItemClass> builder)
        {
            builder.HasKey(t => t.ItemClassId);
        }

    }
}
