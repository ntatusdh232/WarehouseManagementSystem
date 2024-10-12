namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceipt>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceipt> builder)
        {
            builder.HasKey(f => f.FinishedProductReceiptId);

            builder.HasOne(f => f.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductReceipt>(f => f.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey(f => f.FinishedProductReceiptId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
