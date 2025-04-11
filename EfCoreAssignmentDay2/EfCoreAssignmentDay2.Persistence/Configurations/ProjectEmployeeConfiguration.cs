using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay2.Persistence.Configurations
{
    internal class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.ToTable("Project_Employee");

            builder.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            builder.HasOne(pe => pe.Project)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new ProjectEmployee { ProjectId = 1, EmployeeId = 1, Enable = true },
               new ProjectEmployee { ProjectId = 2, EmployeeId = 2, Enable = true },
               new ProjectEmployee { ProjectId = 1, EmployeeId = 2, Enable = false }
           );
        }
    }
}
