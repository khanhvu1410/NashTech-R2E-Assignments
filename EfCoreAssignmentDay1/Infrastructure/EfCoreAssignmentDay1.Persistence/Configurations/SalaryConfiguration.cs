using EfCoreAssignmentDay1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreAssignmentDay1.Persistence.Configurations
{
    internal class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.Property(s => s.SalaryValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
