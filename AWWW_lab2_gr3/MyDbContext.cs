using Microsoft.EntityFrameworkCore; 
// using Microsoft.EntityFrameworkCore.Tools; 
//using Microsoft.EntityFrameworkCore.UseSqlServer; 
// using Microsoft.EntityFrameworkCore.Proxies; 
using AWWW_lab2_gr3.Models;
public class MyDbContext : DbContext{

    public DbSet<Match> Matches { get; set; }
  
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