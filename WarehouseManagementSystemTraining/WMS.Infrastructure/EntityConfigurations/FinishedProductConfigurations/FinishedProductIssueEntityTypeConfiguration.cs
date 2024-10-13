namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssue>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssue> builder)
        {
            builder.HasKey(f => f.FinishedProductIssueId);

            builder.HasOne(f => f.Employee)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<FinishedProductIssue>(f => f.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey(f => f.FinishedProductIssueId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
