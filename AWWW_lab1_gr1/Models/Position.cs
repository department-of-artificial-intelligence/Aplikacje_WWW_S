namespace AWWW_lab1_gr1.Models;
public class Position{
   public int Id{get;set;}
   public string Name{get;set;}
   public virtual ICollection<Player> Players {get;set;}
}