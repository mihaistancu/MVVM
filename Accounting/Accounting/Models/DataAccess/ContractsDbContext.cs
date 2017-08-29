using System.Data.Entity;

namespace Accounting.Models.DataAccess
{
    class ContractsDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasKey(c => c.Number);
            modelBuilder.Entity<Provider>().HasKey(c => c.Name);
            modelBuilder.Entity<Buyer>().HasKey(c => c.Name);
        }
    }
}
