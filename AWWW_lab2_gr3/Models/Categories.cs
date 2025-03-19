namespace AWWW_lab1_gr3.Models {
    public class Category {
        public int Id {get; set;}
        public string Name {get;set;}
        
        public ICollection<Articles> Articles {get;set;}
    }
}