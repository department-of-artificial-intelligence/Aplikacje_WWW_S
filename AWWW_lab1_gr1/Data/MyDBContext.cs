using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
namespace AWWW_lab1_gr1.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        DbSet<League> Leagues { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<MatchEvent> MatchEvents { get; set; }
        DbSet<MatchPlayer> MatchPlayers { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Team> Teams { get; set; }

    }
}
