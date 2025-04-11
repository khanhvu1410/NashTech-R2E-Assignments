using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay2.Persistence.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
            .HasMaxLength(50);

            builder.HasData(
                new Project { Id = 1, Name = "Project A" },
                new Project { Id = 2, Name = "Project B" }
            );
        }
    }
}
