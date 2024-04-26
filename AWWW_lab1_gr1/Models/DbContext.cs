using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class LabOneContext : DbContext
{

    public string DbPath { get; }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchEvent> MatchEvents { get; set; }
    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<EventType> EventTypes { get; set; }

    public DbSet<PlayerPosition> PlayerPositions { get; set; }


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

        modelBuilder.Entity<Player>()
       .HasMany(e => e.Positions)
       .WithMany(e => e.Players)
       .UsingEntity<PlayerPosition>();


    }

    public LabOneContext(DbContextOptions<LabOneContext> options)
            : base(options)
    { }


    public LabOneContext()
    {

    }

}