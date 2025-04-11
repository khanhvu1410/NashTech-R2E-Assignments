using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay2.Persistence.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Department
                {
                    Id = 1,
                    Name = "Software Development"
                },
                new Department
                {
                    Id = 2,
                    Name = "Finance"
                },
                new Department
                {
                    Id = 3,
                    Name = "Accountant"
                },
                new Department
                {
                    Id = 4,
                    Name = "HR"
                }
            );
        }
    }
}
