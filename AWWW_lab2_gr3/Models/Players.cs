namespace AWWW_lab2_gr3.Models {
    public class Player {
        public int Id {get; set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Country {get;set;}
        public DateTime BirthDate {get;set;}
        
        public virtual Team? Team {get;set;}
        public int TeamId {get;set;}
        public ICollection<Position>? Positions {get;set;}
        public ICollection<MatchPlayer>? MatchPlayers {get;set;}

        public Player() {
            Team = null;
            Positions = new List<Position>();
            MatchPlayers = new List<MatchPlayer>();
        }
    }
}