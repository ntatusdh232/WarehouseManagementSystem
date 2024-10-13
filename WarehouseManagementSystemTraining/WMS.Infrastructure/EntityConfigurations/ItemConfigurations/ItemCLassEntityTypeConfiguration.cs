namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemCLassEntityTypeConfiguration : IEntityTypeConfiguration<ItemClass>
    {
        public void Configure(EntityTypeBuilder<ItemClass> builder)
        {
            builder.HasKey(t => t.ItemClassId);

            builder.HasOne(t => t.Item)
                   .WithMany(t => t.ItemClasses)
                   .HasForeignKey(t => t.Itemid)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
