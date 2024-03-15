 using System.data.Entity;
 
 namespace AWWW_lab1_gr2.Models{

public class DbContext:DbContext{
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