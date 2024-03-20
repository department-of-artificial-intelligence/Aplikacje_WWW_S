using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MatchEvent{
       public int Id {get; set;}

       [Display(Name = "Minute")]
       public int Minute{get; set;}

       //
    public virtual Match? Match {get;set;}
    public int MatchId {get;set;}

    public virtual MatchPlayer? MatchPlayer {get;set;}
    public int? MatchPlayerId {get;set;}
        
    public virtual EventType? EventType {get;set;}
    public int EventTypeId {get;set;}
          
}