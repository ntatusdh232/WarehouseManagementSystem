namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceipt>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceipt> builder)
        {
            builder.HasKey(f => f.FinishedProductReceiptId);

            builder.HasOne(f => f.Employee)
                   .WithMany()
                   .IsRequired(false);

            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
