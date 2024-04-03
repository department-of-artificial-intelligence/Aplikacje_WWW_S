namespace AWWW_lab1_gr5.Models
{
    public class EventType
    {
        public int Id {get; set;}
        public string Name {get; set;} = null!;
        public virtual ICollection<MatchEvent>? MatchEvents {get; set;}

    }
}