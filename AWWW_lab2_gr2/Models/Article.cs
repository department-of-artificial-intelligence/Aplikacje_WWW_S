using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Article{
       public int Id {get; set;}

       [StringLength(50)]
       [Display(Name = "Title")]
       public string? Title{get; set;}

        [StringLength(500)]
        [Display(Name = "Lead")]
       public string? Lead {get;set;}

       [StringLength(5000)]
       [Display(Name = "Content")]
       public string? Content {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
       public DateTime CreationDate{get; set;}

       //

        public virtual Author Author{get; set;}
        public int AuthorId{get; set;}


        public virtual Category? Category{get; set;}
        public int CategoryId{get; set;}
        
        public virtual ICollection<Tag>? Tag{get; set;}

        public virtual ICollection<Comment>? Comments{get; set;}

        public virtual Match? Match {get;set;}
        public int? MatchId {get;set;}

}