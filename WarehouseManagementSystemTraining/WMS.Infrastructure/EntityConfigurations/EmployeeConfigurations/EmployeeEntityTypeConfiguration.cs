namespace WMS.Infrastructure.EntityConfigurations.EmployeeConfigurations
{
    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(t => t.EmployeeId);

        }
    }
}
