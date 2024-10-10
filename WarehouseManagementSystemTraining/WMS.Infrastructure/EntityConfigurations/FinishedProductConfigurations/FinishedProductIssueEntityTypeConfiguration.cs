namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssue>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssue> builder)
        {
            builder.HasKey(f => f.FinishedProductIssueId);

            // Cấu hình mối quan hệ One-to-One với Employee
            builder.HasOne(f => f.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductIssue>(f => f.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ One-to-Many với FinishedProductIssueEntry
            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("FinishedProductIssueId")
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
