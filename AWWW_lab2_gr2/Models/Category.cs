using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Category{
       public int Id{get; set;}
       
       [StringLength(50)]
       [Display(Name = "Name")]
       public string Name{get; set;} = null?;
       public virtual ICollection<Article>? Articles{get; set;}

}