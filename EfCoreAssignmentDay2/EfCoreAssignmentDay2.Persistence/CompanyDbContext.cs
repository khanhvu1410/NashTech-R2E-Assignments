using System.Reflection;
using EfCoreAssignmentDay2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay2.Persistence
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Salaries> Salaries { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    }

}
