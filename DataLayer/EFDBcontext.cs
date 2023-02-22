using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBcontext : DbContext
    {
        public DbSet<SotrudnikEntity> Sotrudnikis { get; set; }
        public DbSet<ChildEntity> ChildEntity { get; set; }

        public EFDBcontext(DbContextOptions<EFDBcontext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildEntity>()
                .HasOne(u => u.Sotrudnik)
                .WithMany(c => c.Children)
                .HasForeignKey(u => u.SotrudnikId);
        }
    }
    public class EFDbcontextFactory : IDesignTimeDbContextFactory<EFDBcontext>
    {
        public EFDBcontext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<EFDBcontext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SotrudnikDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DomainLayer"));
            return new EFDBcontext(optionBuilder.Options);
        }
    }
}
