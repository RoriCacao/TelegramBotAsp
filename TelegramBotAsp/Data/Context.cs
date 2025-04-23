using Microsoft.EntityFrameworkCore;
using TelegramBotAsp.Models;

namespace TelegramBotAsp.Context
{
    public class ApContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
      //  public DbSet<Country> Countries { get; set; } = null!;
        public ApContext()
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");//(@"Data Source=DESKTOP-J7SMN7O;Initial Catalog=master;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Company>();
        }
    }
}
