using Microsoft.EntityFrameworkCore; 
using AWWW_lab2_gr3.Models;
public class MyDbContext : DbContext{

    public DbSet<Match> Matches { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Article> Articles { get; set; }
     public DbSet<Author> Authors { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<MatchEvent> MatchEvents { get; set; }
    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<Player> Playeres { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<League> Leagues { get; set; }
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

        modelBuilder.Entity<Article>()
            .HasOne(m => m.Author)
            .WithMany(t => t.Articles)
            .HasForeignKey(m => m.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Article>()
            .HasOne(m => m.Category)
            .WithMany(t => t.Articles)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Article>()
            .HasOne(m => m.Match)
            .WithMany(t => t.Articles)
            .HasForeignKey(m => m.MatchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comment>()
            .HasOne(m => m.Article)
            .WithMany(t => t.Comments)
            .HasForeignKey(m => m.ArticleId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<MatchEvent>()
            .HasOne(m => m.MatchPlayer)
            .WithMany(t => t.MatchEvents)
            .HasForeignKey(m => m.MatchPlayerId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<MatchEvent>()
            .HasOne(m => m.Match)
            .WithMany(t => t.MatchEvents)
            .HasForeignKey(m => m.MatchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MatchEvent>()
            .HasOne(m => m.EventType)
            .WithMany(t => t.MatchEvents)
            .HasForeignKey(m => m.EventTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MatchPlayer>()
            .HasOne(m => m.Player)
            .WithMany(t => t.MatchPlayers)
            .HasForeignKey(m => m.PlayerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MatchPlayer>()
            .HasOne(m => m.Match)
            .WithMany(t => t.MatchPlayers)
            .HasForeignKey(m => m.MatchId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MatchPlayer>()
            .HasOne(m => m.Position)
            .WithMany(t => t.MatchPlayers)
            .HasForeignKey(m => m.PositionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Player>()
            .HasOne(m => m.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(m => m.TeamId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Team>()
            .HasOne(m => m.League)
            .WithMany(t => t.Teams)
            .HasForeignKey(m => m.LeagueId)
            .OnDelete(DeleteBehavior.NoAction);
    }
 
}