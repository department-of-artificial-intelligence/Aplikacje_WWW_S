namespace AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.Models;
    public class Article{
        public  int ID{get; set;}
        public required string Title{get; set;}
        public required string Content{get;set;}
        public required string Lead{get;set;}
        public  DateTime CreationDate{get;set;}
        public  List<Comment>? Comments{get;set;}
        public required Category Category{get;set;}
        public required Author Authors{get;set;}
        public List<Tag>? Tags{get;set;}
        public Match? Match{get;set;}

    }