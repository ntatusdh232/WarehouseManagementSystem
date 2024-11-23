using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Infrastructure.EntityConfigurations.DepartmentConfigurations
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(s => s.DepartmentId);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(60);

        }
    }
}


