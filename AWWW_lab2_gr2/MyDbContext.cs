using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr2.Models;

public class MyDbContext : DbContext {
    
    DbSet<Article> Articles {get; set;}
    DbSet<Author> Authors {get; set;}
    DbSet<Category> Categories {get; set;}
    DbSet<Comment> Comments {get;set;}
    DbSet<EventType> EventTypes {get;set;}
    DbSet<League> Leagues {get;set;}
    DbSet<Match> Matches {get;set;}
    DbSet<MatchEvent> MatchEvents {get;set;}
    DbSet<MatchPlayer> MatchPlayers {get;set;}
    DbSet<Player> Players {get;set;}
    DbSet<Position> Positions {get;set;}
    DbSet<Tag> Tags {get;set;}
    DbSet<Team> Teams {get;set;}
    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){

    }
    
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