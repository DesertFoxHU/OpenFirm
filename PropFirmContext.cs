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
    }
}
