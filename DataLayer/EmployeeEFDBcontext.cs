using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class EmployeeEFDBcontext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Child> Childrens { get; set; }

        public EmployeeEFDBcontext(DbContextOptions<EmployeeEFDBcontext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>()
                .HasOne(u => u.Employee)
                .WithMany(c => c.Children)
                .HasForeignKey(u => u.EmployeeId);
        }
    }
}
