using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay2.Persistence.Configurations
{
    internal class SalariesConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            builder.Property(s => s.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(s => s.Employee)
                .WithOne(e => e.Salary)
                .HasForeignKey<Salaries>(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Salaries { Id = 1, EmployeeId = 1, Salary = 5000 },
                new Salaries { Id = 2, EmployeeId = 2, Salary = 7000 }
            );
        }
    }
}
