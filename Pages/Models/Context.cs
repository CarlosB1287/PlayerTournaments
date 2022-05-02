using Microsoft.EntityFrameworkCore;

namespace PlayerTournaments.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTournament>().HasKey(s => new {s.TournamentID, s.PlayerID});
        }

        public DbSet<Tournament> Tournament {get; set;}

        public DbSet<Player> Player {get; set;}

        public DbSet<PlayerTournament> PlayerTournament {get; set;}
    }
}
