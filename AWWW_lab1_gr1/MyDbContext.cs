using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

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


            //Moje Inicjalizacja bazy danymi
            modelBuilder.Entity<Author>().HasData(new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    FirstName = "Mateusz",
                    LastName = "Janik",
                    Articles = new List<Article>()
                    {
                        new Article
                        {
                            Id = 1,
                            Title = "First article",
                            Lead = "Read it",
                            Content = "Some Content",
                            CreationDate = DateTime.Now,
                            Author = new Author(),
                            Category = new Category(),
                            Tags = new List<Tag>(),
                            Comments = new List<Comment>(),
                            Match = new Match() {}
                        }
                    }
                }
            });
        }
    }  
}
