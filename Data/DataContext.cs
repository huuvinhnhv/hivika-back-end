global using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Web_Api_Event_Game.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EventGame> EventGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Events)
                .WithOne(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Coupons)
                .WithOne(c => c.Game)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventGame>()
                .HasKey(eg => new { eg.EventId, eg.GameId });

            modelBuilder.Entity<EventGame>()
                .HasOne(eg => eg.Event)
                .WithMany(e => e.EventGames)
                .HasForeignKey(eg => eg.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventGame>()
                .HasOne(eg => eg.Game)
                .WithMany(g => g.EventGames)
                .HasForeignKey(eg => eg.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Coupon>()
                .HasOne(c => c.Game)
                .WithMany(g => g.Coupons)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
