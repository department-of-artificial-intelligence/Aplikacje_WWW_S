using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MatchPlayer{
       public int Id {get; set;}

       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       [Display(Name = "Start Time")]
       public DateTime StartTime {get; set;}

       [Display(Name = "End Time")]
       public DateTime EndTime {get; set;}
       
       //
    public virtual Player Player {get;set;}
    public int PlayerId {get;set;}

    public virtual Position Position {get;set;}
    public int PositionId {get;set;}

    public virtual Match Match {get;set;}
    public int MatchId {get;set;}
      
}