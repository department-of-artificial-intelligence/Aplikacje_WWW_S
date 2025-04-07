using AWWW_lab02_gr3.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Article> Articles {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<EventType> EventTypes {get; set;}
    public DbSet<League> Leagues {get; set;}
    public DbSet<Match> Matches {get; set;}
    public DbSet<MatchEvent> MatchEvents {get; set;}
    public DbSet<MatchPlayer> MatchPlayers {get; set;}
    public DbSet<Player> Players {get; set;}
    public DbSet<Position> Positions {get; set;}
    public DbSet<Tag> Tags {get; set;}
    public DbSet<Team> Teams {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}