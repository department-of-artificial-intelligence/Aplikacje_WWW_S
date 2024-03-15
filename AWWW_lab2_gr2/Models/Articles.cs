using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Article
{
    public int Id {get;set;}=null!;
    public string Title{get;set;}=null!;
    public string Lead{get;set;}=null!;
    public string Content {get;set;}=null!;
    public DateTime CreationDate{get;set;}
    public Author autor{get;set;}=null!;
    public Category categoria{get;set;}  =null!;                
    public ICollection<Comment> komentarze{get;set}
    public ICollection<Tag> tagi{get;set} =null!;
    public Match? match{get;set;}
}