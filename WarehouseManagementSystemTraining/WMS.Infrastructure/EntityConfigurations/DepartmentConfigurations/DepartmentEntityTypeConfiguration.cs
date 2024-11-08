using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Infrastructure.EntityConfigurations.DepartmentConfigurations;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasNoKey();
        builder
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(60);

    }
}
