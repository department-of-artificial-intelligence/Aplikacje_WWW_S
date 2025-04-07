namespace AWWW_lab2_gr3.Models
{
    public class Position
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public virtual Player Player { get; set;}
        public int PlayerId {get; set;}
        public virtual MatchPlayer MatchPlayer {get; set;}
        public int MatchPlayerId {get; set;}
    }
}