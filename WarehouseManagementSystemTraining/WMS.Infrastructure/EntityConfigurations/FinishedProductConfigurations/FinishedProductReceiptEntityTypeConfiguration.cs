namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductReceiptEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductReceipt>
    {
        public void Configure(EntityTypeBuilder<FinishedProductReceipt> builder)
        {
            builder.HasKey(f => f.FinishedProductReceiptId);

            // Cấu hình mối quan hệ One-to-One với Employee
            builder.HasOne(f => f.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductReceipt>(f => f.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-Many với FinishedProductReceiptEntry
            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("FinishedProductReceiptId")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
