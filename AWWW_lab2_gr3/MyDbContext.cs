using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr3.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace AWWW_lab2_gr3 {
    public class MyDbContext : DbContext {
        public virtual DbSet<Author> Authors {get;set;}
        public virtual DbSet<Article> Articles {get;set;}
        public virtual DbSet<Category> Categories {get;set;}
        public virtual DbSet<Comment> Comments {get;set;}
        public virtual DbSet<Tag> Tags {get;set;}
        public virtual DbSet<League> Leagues {get;set;}
        public virtual DbSet<Team> Teams {get;set;}
        public virtual DbSet<Match> Matches {get;set;}
        public virtual DbSet<Player> Players {get;set;}
        public virtual DbSet<Position> Positions {get;set;}
        public virtual DbSet<MatchPlayer> MatchPlayers {get;set;}
        public virtual DbSet<MatchEvent> MatchEvents {get;set;}
        public virtual DbSet<EventType> EventTypes {get;set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<A>()
            //            .HasOne(a => a.B)
            //            .WithOne(b => b.A)
            //            .HasForeignKey<A>(a => a.BId);

            // Article <=> Category
            modelBuilder.Entity<Article>()
                .HasOne(a=>a.Category)
                .WithMany(c=>c.Articles)
                .HasForeignKey(a=>a.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article <=> Author
            modelBuilder.Entity<Article>()
                .HasOne(a=>a.Author)
                .WithMany(a=>a.Articles)
                .HasForeignKey(a=>a.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article <=> Match
            modelBuilder.Entity<Article>()
                .HasOne(a=>a.Match)
                .WithMany(m=>m.Articles)
                .HasForeignKey(a=>a.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article <=> Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c=>c.Article)
                .WithMany(a=>a.Comments)
                .HasForeignKey(c=>c.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article <=> Tag
            /*modelBuilder.Entity<Article>()
                .HasMany(a=>a.Tags)
                .WithMany(t=>t.Articles);
            */
            // Team <=> League
            modelBuilder.Entity<Team>()
                .HasOne(t=>t.League)
                .WithMany(l=>l.Teams)
                .HasForeignKey(t=>t.LeagueId)
                .OnDelete(DeleteBehavior.NoAction);

            // Player <=> Team
            modelBuilder.Entity<Player>()
                .HasOne(p=>p.Team)
                .WithMany(t=>t.Players)
                .HasForeignKey(p=>p.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            // Team <=> League
            modelBuilder.Entity<Team>()
                .HasOne(t=>t.League)
                .WithMany(l=>l.Teams)
                .HasForeignKey(t=>t.LeagueId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Player <=> Position
            modelBuilder.Entity<Player>()
                .HasMany(p=>p.Positions)
                .WithMany(p=>p.Players);

            // Match <=> Team
            modelBuilder.Entity<Match>()
                .HasOne(m=>m.HomeTeam)
                .WithMany(t=>t.HomeMatches)
                .HasForeignKey(m=>m.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);
            

            modelBuilder.Entity<Match>()
                .HasOne(m=>m.AwayTeam)
                .WithMany(t=>t.AwayMatches)
                .HasForeignKey(m=>m.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}