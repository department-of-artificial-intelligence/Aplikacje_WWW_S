namespace AWWW_lab1_gr2.Models{
    public class MatchPlayer{
        public int Id{get;set;}
        public DateTime StartTime{get;set;}
        public DateTime EndTime{get;set;}
        public Match Match{get;set;}=null!;
        public Position Position{get;set;}=null!;
        public Player Player{get;set;}=null!;
    }
}