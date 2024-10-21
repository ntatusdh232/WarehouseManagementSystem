namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssue>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssue> builder)
        {
            builder.HasKey(f => f.FinishedProductIssueId);

            // Cấu hình mối quan hệ One-to-Many với Employee
            builder.HasOne(f => f.Employee)
                   .WithMany()
                   .HasForeignKey(g => g.EmployeeId)
                   .IsRequired(false);

            // Cấu hình mối quan hệ One-to-Many với FinishedProductIssueEntry
            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("FinishedProductIssueId")
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
