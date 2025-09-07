using Contract_Tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Contract_Tracking_System.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Guarantee> guarantees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
