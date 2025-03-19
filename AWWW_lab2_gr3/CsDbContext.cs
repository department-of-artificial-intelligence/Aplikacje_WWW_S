using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3
{
    public class CsDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments {get; set;}
        public virtual DbSet<Author> Authors {get; set;}
        public virtual DbSet<Tag> Tags {get; set;}
        public virtual DbSet<Team> Teams {get; set;}
        public virtual DbSet<MatchEvent> MatchEvents {get; set;}
        public virtual DbSet<MatchPlayer> MatchPlayer {get; set;}
        public virtual DbSet<Position> Positions {get; set;}
        public virtual DbSet<Player> Players { get; set;}
        public virtual DbSet<Match> Matches {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany(t => t.HomeMatches)
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany(t => t.AwayMatches)
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    }
}