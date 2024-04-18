namespace AWWW_lab1_gr2.Models{
    public class Match{
        public int Id{get;set;}
        public DateTime Date{get;set;}
        public string? Stadium{get;set;}
        public int AwayTeamId{get;set;}
        public int HomeTeamId{get;set;}
        public Team AwayTeam{get;set;}=null!;
        public Team HomeTeam{get;set;}=null!;

    }

}