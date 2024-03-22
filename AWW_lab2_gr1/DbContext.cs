using Microsoft.EntityFrameworkCore;
using AWW_lab2_gr1.Models;

namespace AWW_lab2_gr1
{
  public class MyDbContext : DbContext
  {
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<EventType> EventTypes { get; set; }
    public virtual DbSet<League> Leagues { get; set; }
    public virtual DbSet<Match> Matches { get; set; }
    public virtual DbSet<MatchEvent> MatchEvents { get; set; }
    public virtual DbSet<MatchPlayer> MatchPlayers { get; set; }
    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Team> Teams { get; set; }


    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

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
}