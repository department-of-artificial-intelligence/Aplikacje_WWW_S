using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Position{
       public int Id {get; set;}

       [StringLength(50)]
       [Display(Name = "Name")]
       public string Name {get; set;} =null!;

       public virtual ICollection<MatchPlayer>? MatchPlayers {get;set;}
       public virtual ICollection<Player>? Players {get;set;}
}