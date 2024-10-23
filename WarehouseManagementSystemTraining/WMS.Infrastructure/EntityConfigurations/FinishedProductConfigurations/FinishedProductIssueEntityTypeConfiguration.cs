namespace WMS.Infrastructure.EntityConfigurations.FinishedProductConfigurations
{
    public class FinishedProductIssueEntityTypeConfiguration : IEntityTypeConfiguration<FinishedProductIssue>
    {
        public void Configure(EntityTypeBuilder<FinishedProductIssue> builder)
        {
            builder.HasKey(f => f.FinishedProductIssueId);

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
