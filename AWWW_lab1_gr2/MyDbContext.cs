using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;


    public class MyDbContext:DbContext{
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options){}
        public DbSet<Article> Articles{get;set;}
        public DbSet<Author> Author{get;set;}
        public DbSet<Category> Category{get;set;}
        public DbSet<Comment> Comment{get;set;}
        public DbSet<EventType> EventType{get;set;}
        public DbSet<League> League{get;set;}
        public DbSet<Match> Match{get;set;}
        public DbSet<MatchEvent> MatchEvent{get;set;}
        public DbSet<MatchPlayer> MatchPlayer{get;set;}
        public DbSet<Player> Player{get;set;}
        public DbSet<Position> Position{get;set;}
        public DbSet<Student> Student{get;set;}
        public DbSet<Tag> Tag{get;set;}
        public DbSet<Team> Team{get;set;}


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


