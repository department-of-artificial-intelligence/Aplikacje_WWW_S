
namespace AWWW_lab1_gr3.Models {
    public class Article {
        public int Id {get; set;}
        public string Title {get;set;}
        public string Lead {get;set;}
        public string Content {get;set;}
        public DateTime CreationDate { get;set;}

        public int AuthorId {get;set;}
        public int CategoryId {get;set;}
        public ICollection<Tags> Tags {get;set;}
        public int MatchId {get;set;}
        public ICollection<Comment> Comments {get;set;}

    }
}
