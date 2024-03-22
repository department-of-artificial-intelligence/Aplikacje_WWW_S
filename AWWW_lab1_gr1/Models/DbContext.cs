using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AWWW_lab1_gr1.Models;


namespace AWWW_lab1_gr1 {
    public class MyDbContext : DbContext {
        public string DbPath { get; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<MatchEvent> MatchEvents { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<MatchPlayer> MatchPlayers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        
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

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        
    }

   

     

}

