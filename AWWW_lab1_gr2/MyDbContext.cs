using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2;
public class MyDbContext : DbContext
{
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Author> Author { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<Comment> Comment { get; set; }
    public virtual DbSet<EventType> EventType { get; set; }
    public virtual DbSet<League> League { get; set; }
    public virtual DbSet<Match> Match { get; set; }
    public virtual DbSet<MatchEvent> MatchEvent { get; set; }
    public virtual DbSet<MatchPlayer> MatchPlayer { get; set; }
    public virtual DbSet<Player> Player { get; set; }
    public virtual DbSet<Position> Position { get; set; }
    public virtual DbSet<Tag> Tag { get; set; }
    public virtual DbSet<Team> Team { get; set; }


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