namespace WMS.Infrastructure.EntityConfigurations.GoodsIssueConfigurations
{
    public class GoodsIssueEntityTypeConfiguration : IEntityTypeConfiguration<GoodsIssue>
    {
        public void Configure(EntityTypeBuilder<GoodsIssue> builder)
        {
            builder.HasKey(g => g.GoodsIssueId);

            builder.HasOne(g => g.Employee)
               .WithMany()
               .HasForeignKey(g => g.EmployeeId)
               .IsRequired(false);


            builder.HasMany(g => g.Entries)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey("GoodsIssueId")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
