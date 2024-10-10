namespace WMS.Infrastructure.EntityConfigurations.ItemConfigurations
{
    public class ItemCLassEntityTypeConfiguration : IEntityTypeConfiguration<ItemClass>
    {
        public void Configure(EntityTypeBuilder<ItemClass> builder)
        {
            builder.HasKey(t => t.ItemClassId);

            builder.HasOne(ic => ic.Item)
                   .WithMany(i => i.ItemClasses)
                   .HasForeignKey(ic => ic.Itemid)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
