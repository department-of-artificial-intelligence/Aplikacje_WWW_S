namespace AWWW_lab1_gr2.Models
{
    public class Match
    {
        public int Id {get; set;}
        public string? Stadium {get; set;}
        public DateTime Date {get; set;}
        public Team? HomeTeam {get; set;}
        public Team? Opponents {get; set;}
    }
}