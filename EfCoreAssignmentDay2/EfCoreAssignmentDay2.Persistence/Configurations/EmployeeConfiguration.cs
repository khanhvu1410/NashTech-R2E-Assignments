using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay2.Persistence.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.JoinedDate)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Employee { Id = 1, Name = "Alice", JoinedDate = new DateTime(2022, 1, 10), DepartmentId = 1 },
                new Employee { Id = 2, Name = "Bob", JoinedDate = new DateTime(2024, 5, 20), DepartmentId = 2 }
            );
        }
    }
}
