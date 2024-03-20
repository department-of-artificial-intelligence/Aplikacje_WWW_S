using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Comment{
       public int Id {get; set;}

       [StringLength(50)]
       [Display(Name = "Title")]
       public string? Title{get; set;}

       [StringLength(500)]
       [Display(Name = "Content")]
       public string Content {get; set;} = null;

       public int ArticleId {get;set;}
        public virtual Article? Article {get;set;}
      
}