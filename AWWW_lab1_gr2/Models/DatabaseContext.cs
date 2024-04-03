using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext: DbContext { 
    public DatabaseContext() {} 
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
    public DbSet<Article> Articles {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<EventType> EventTypes {get; set;}
    public DbSet<Match> Matches {get; set;}
    public DbSet<MatchEvent> MatchEvents {get; set;}
    public DbSet<MatchPlayer> MatchPlayers {get; set;}
    public DbSet<Player> Players {get; set;}
    public DbSet<Position> Positions {get; set;}
    public DbSet<Student> Students {get; set;}
    public DbSet<Tag> Tags {get; set;}
    public DbSet<Team> Teams {get; set;}

    public DbSet<League> Leagues {get; set;}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //     optionsBuilder.UseLazyLoadingProxies(); 
    // }

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

        modelBuilder.Entity<Team>()
            .HasOne(t => t.League)
            .WithMany(l => l.Teams)
            .HasForeignKey(t => t.LeagueId); 


        modelBuilder.Entity<Article>(entity => {
            entity.ToTable("Articles"); 

        });
        modelBuilder.Entity<Author>(entity => {
            entity.ToTable("Authors"); 

        });
        modelBuilder.Entity<Category>(entity => {
            entity.ToTable("Categories"); 

        });
        modelBuilder.Entity<Comment>(entity => {
            entity.ToTable("Comments"); 

        });
        modelBuilder.Entity<EventType>(entity => {
            entity.ToTable("EventTypes"); 

        });
        modelBuilder.Entity<Match>(entity => {
            entity.ToTable("Matches"); 

        });
        modelBuilder.Entity<MatchEvent>(entity => {
            entity.ToTable("MatchEvents"); 

        });
        modelBuilder.Entity<MatchPlayer>(entity => {
            entity.ToTable("MatchPlayers"); 

        });
        modelBuilder.Entity<Player>(entity => {
            entity.ToTable("Players"); 

        });
        modelBuilder.Entity<Position>(entity => {
            entity.ToTable("Positions"); 

        });
        modelBuilder.Entity<Student>(entity => {
            entity.ToTable("Students"); 

        });
        modelBuilder.Entity<Tag>(entity => {
            entity.ToTable("Tags"); 

        });
        modelBuilder.Entity<Team>(entity => {
            entity.ToTable("Teams"); 

        });
        modelBuilder.Entity<League>(entity => {
            entity.ToTable("Leagues"); 

        });
    }


    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite("Filename=:memory:");
    // }
}