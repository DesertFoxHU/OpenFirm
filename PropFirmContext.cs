using Microsoft.EntityFrameworkCore;

namespace OpenFirm
{
    public class PropFirmContext : DbContext
    {
        public PropFirmContext(DbContextOptions<PropFirmContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Account>()
                .Property(a => a.InitialBalance)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Trade>()
                .Property(t => t.Profit)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Trade>()
                .Property(t => t.LotSize)
                .HasPrecision(18, 4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
