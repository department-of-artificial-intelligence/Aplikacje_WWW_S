using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;

public class Article{
       public int Id{get; set;}
       public string Title{get; set;}
       public string Content {get; set;}
       public DateTime CreationDate{get; set;}

        public virtual Author Author{get; set;}
        public int AuthorId{get; set;}

        public virtual Category Category{get; set;}
        public int CategoryId{get; set;}

        public virtual Tag Tag{get; set;}
        public int TagId{get; set;}

        public virtual Match Match{get; set;}
        public int MatchId{get; set;}

}