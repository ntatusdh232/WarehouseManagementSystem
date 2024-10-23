namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductInventoryEntryEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductInventory>
    {
        public void Configure(EntityTypeBuilder<FinishedProductInventory> builder)
        {
            builder.HasKey(f => f.FinishedProductInventoryId);

            builder.HasOne(f => f.Item)
                   .WithMany()
                   .IsRequired(false);


        }
    }
}
