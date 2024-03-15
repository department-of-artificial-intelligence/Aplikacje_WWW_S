using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class League{
       public int Id{get; set;}

      [StringLength(50)]
      [Display(Name = "Name")]
      public string Name{get; set;}

      [StringLength(50)]
      [Display(Name = "Country")]
      public string Country{get; set;}
      
      [Display(Name = "Level")]
      public int Level{get; set;}


      public virtual ICollection<Team> Teams{get; set;}
       
      
}