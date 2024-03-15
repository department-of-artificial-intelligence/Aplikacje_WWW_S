using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr2.Models;

namespace AWWW_lab2_gr2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lab2_gr2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity
                    .HasOne(a => a.Author)
                    .WithMany(b => b.Articles)
                    .HasForeignKey(a => a.AuthorId)
                    .IsRequired();

                entity
                    .HasOne(a => a.Category)
                    .WithMany(b => b.Articles)
                    .HasForeignKey(a => a.CategoryId)
                    .IsRequired();

                entity
                    .HasMany(a => a.Comments)
                    .WithOne(b => b.Article)
                    .HasForeignKey(a => a.ArticleId);

                entity
                    .HasMany(a => a.Tags)
                    .WithMany(b => b.Articles);

                entity
                    .HasOne(a => a.Match)
                    .WithMany(b => b.Articles)
                    .HasForeignKey(a => a.MatchId)
                    .IsRequired(false);
            });
        }
    } 
}
