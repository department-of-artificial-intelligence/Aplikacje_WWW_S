using AWWW_lab2_gr2.Models;
using Microsoft.EntityFrameworkCore;
// using System.Data.Entity.DbSet;

public class MyContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Article> Articles { get; set; }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public DbSet<Match> Matches { get; set; }

    public DbSet<MatchEvent> MatchEvents { get; set; }

    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }

    public DbSet<Player> Players { get; set; }
    public DbSet<Position> Positions { get; set; }

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
