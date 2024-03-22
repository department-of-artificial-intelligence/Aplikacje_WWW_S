using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Article
{
    public int Id {get;set;}
    public string Title{get;set;}
    public string Lead{get;set;}
    public string Content {get;set;}
    public DateTime CreationDate{get;set;}
    public Author autor{get;set;}=null!;
    public Category categoria{get;set;}  =null!;                
    public ICollection<Comment> komentarze{get;set}
    public ICollection<Tag> tagi{get;set}
    public Match? match{get;set;}
}