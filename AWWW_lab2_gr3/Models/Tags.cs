namespace AWWW_lab1_gr3.Models {
    public class Tag {
        public int Id {get; set;}
        public string Name {get;set;}
        
        public ICollection<Article> Articles {get;set;}
    }
}