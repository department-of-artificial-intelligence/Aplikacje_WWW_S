namespace AWWW_lab1_gr5.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; }


    }
}