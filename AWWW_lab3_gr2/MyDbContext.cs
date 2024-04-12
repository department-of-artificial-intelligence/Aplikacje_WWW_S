using Microsoft.EntityFrameworkCore;
using AWWW_lab3_gr2.Models;

namespace AWWW_lab3_gr2;
public class MyDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Match>().HasMany(m => m.MatchEvents).WithOne(me => me.Match).HasForeignKey(me => me.MatchId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Match>().HasOne(m => m.HomeTeam).WithMany(l => l.HomeMatches).HasForeignKey(m => m.HomeTeamId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Match>().HasOne(m => m.AwayTeam).WithMany(l => l.AwayMatches).HasForeignKey(m => m.AwayTeamId).OnDelete(DeleteBehavior.NoAction);
    }
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Article> Article { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<EventType> EventType { get; set; }
    public DbSet<League> League { get; set; }
    public DbSet<Match> Matche { get; set; }
    public DbSet<MatchEvent> MatchEvent { get; set; }
    public DbSet<MatchPlayer> MatchPlayer { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Team> Team { get; set; }

}