using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Match{
       public int Id {get; set;}

       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       [Display(Name = "Date")]
       public DateTime Date {get; set;}

       [StringLength(50)]
        [Display(Name = "Stadium")]
       public string Stadium {get; set;}

       //
       public virtual ICollection<Article> Articles {get;set;}

       public virtual ICollection<MatchEvent> MatchEvents {get;set;}

       public virtual ICollection<MatchPlayer> MatchPlayers {get;set;}


       public int HomeTeamId { get; set; }
       public int AwayTeamId { get; set; }
       public virtual Team HomeTeam { get; set; }
       public virtual Team AwayTeam { get; set; }

      
}