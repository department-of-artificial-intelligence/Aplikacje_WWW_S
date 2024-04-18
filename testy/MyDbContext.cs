using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Models;
public class MyDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam).WithMany(x => x.HomeMatches).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Match>().HasOne(x => x.AwayTeam).WithMany(x => x.AwayMatches).HasForeignKey(x => x.AwayTeamId).OnDelete(DeleteBehavior.NoAction);

        // modelBuilder.Entity<MatchPlayer>().HasKey(m => new {m.MatchId, m.PlayerId});
    }
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Team> Team { get; set; }
    public virtual DbSet<Player> Player { get; set; }
    public virtual DbSet<Match> Match { get; set; }
    public virtual DbSet<Position> Position { get; set; }
    public virtual DbSet<MatchPlayer> MatchPlayer { get; set; }
}