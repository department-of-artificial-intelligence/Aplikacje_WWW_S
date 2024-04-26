public class PlayerPosition
{
    public int PlayerId { get; set; }
    public int PositionId { get; set; }
    public Player Player { get; set; } = null!;
    public Position Position { get; set; } = null!;
}
