using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Team{
       public int Id{get; set;}

      [StringLength(50)]
      [Display(Name = "Name")]
      public string Name{get; set;} = null!;

      [StringLength(50)]
      [Display(Name = "Country")]
      public string Country{get; set;}= null!;
      
      [StringLength(50)]
      [Display(Name = "City")]
      public string City{get; set;}= null!;

      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      [Display(Name = "Founding Date")]
      public DateTime FoundingDate {get; set;}

      //
      public virtual ICollection<Match>? Matches {get;set;}
      public virtual ICollection<Player>? Players {get;set;}
      
      public virtual League? League {get;set;}
      public int LeagueId {get;set;}
       
      
}