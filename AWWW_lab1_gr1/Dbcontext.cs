using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;


namespace AWWW_lab1_gr1;


public class MeBdContext : DbContext
{

public DbSet<Article> Articles { get; set; }
public DbSet<Author> Authorss { get; set; }
public DbSet<Comment> Comments { get; set; }
public DbSet<Category> Categories {get; set;}
public DbSet<EventType> EventTypes { get; set; }
public DbSet<League> Leagues { get; set; }
public DbSet<Match> Matches { get; set; }
public DbSet<MatchEvent> MatchEvents { get; set; }
public DbSet<MatchPlayer> MatchPlayers { get; set; }
public DbSet<Player> Players { get; set; }
public DbSet<Position> Positions  { get; set; }
public DbSet<Tag> Tags { get; set; }
public DbSet<Team> Teams { get; set; }


  public MeBdContext(DbContextOptions<MeBdContext> options):base(options)
  {
    
  }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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

