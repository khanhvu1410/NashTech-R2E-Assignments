using System.Reflection.Emit;
using EfCoreAssignmentDay1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay1.Persistence.Configurations
{
    internal class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            builder.HasOne<Project>(pe => pe.Project)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);

            builder.HasOne<Employee>(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);
        }
    }
}
