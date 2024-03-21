using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext: DbContext { 
    public DatabaseContext() {} 
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
    DbSet<Article> Articles {get; set;}
    DbSet<Author> Authors {get; set;}
    DbSet<Category> Categories {get; set;}
    DbSet<Comment> Comments {get; set;}
    DbSet<EventType> EventTypes {get; set;}
    DbSet<Match> Matches {get; set;}
    DbSet<MatchEvent> MatchEvents {get; set;}
    DbSet<MatchPlayer> MatchPlayers {get; set;}
    DbSet<Player> Players {get; set;}
    DbSet<Position> Positions {get; set;}
    DbSet<Student> Students {get; set;}
    DbSet<Tag> Tags {get; set;}
    DbSet<Team> Teams {get; set;}

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
    }


    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite("Filename=:memory:");
    // }
}