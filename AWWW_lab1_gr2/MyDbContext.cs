using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext:DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchEvent> MatchEvents { get; set; }
    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
        .HasOne(m => m.HomeTeam)
        .WithMany(t => t.HomeMatches)
        .HasForeignKey(m => m.Id)
        .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Match>()
        .HasOne(m => m.AwayTeam)
        .WithMany(t => t.AwayMatches)
        .HasForeignKey(m => m.Id)
        .OnDelete(DeleteBehavior.NoAction);
    }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database provider and connection string here
        optionsBuilder.UseSqlServer(connectionString);
    }
    */
}