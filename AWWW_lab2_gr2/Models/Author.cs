using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Author{
       public int Id {get; set;}

       [StringLength(50)]
       [Display(Name = "First Name")]
       public string? FirstName{get; set;}
       
       [StringLength(50)]
       [Display(Name = "Last Name")]
       public string? LastName {get; set;}
       public virtual ICollection<Article>? Articles{get; set;}
       
}