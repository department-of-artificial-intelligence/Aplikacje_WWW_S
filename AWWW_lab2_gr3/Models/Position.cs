namespace AWWW_lab2_gr3.Models
{
    public class Position
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public Player Players { get; set;}
        public MatchPlayer MatchPlayer {get; set;}
    }
}