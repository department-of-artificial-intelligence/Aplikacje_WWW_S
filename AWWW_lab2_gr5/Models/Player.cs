namespace AWWW_lab1_gr5.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayers { get; set; }
        public int PositionId { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }


    }
}