using System.Reflection;
using EfCoreAssignmentDay1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay1.Persistence.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectEmployee> Salaries { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    }

}
