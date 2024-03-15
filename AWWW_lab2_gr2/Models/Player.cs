using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player{
       public int Id {get; set;}

       [StringLength(50)]
       [Display(Name = "First Name")]
       public string FirstName{get; set;}
       
       [StringLength(50)]
       [Column("LastName")]
       [Display(Name = "Last Name")]
       public string LastName {get; set;}

        [StringLength(50)]
        [Display(Name = "Country")]
       public string Country {get; set;}

       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       [Display(Name = "Birth Date")]
       public DateTime BirthDate{get; set;}

       //
        public virtual Team Team {get;set;}
        public int TeamId {get;set;}
        
        public virtual ICollection<Position> Positions {get;set;}
        public int PositionId {get;set;}

        public virtual ICollection<MatchPlayer> MatchPlayers {get;set;}
}