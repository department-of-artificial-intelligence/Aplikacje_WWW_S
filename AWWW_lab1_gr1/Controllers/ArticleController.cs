using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

 public class ArticleController:Controller{

    public IActionResult Index(int id=1)
    {
        var articles = new List<Article>
        {
            new Article{
            Id = 1,
            Title = "Artykul 1",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now,
            Authors = new Author(){FirstName="asada",LastName="asdas",ID=1},
            Lead = "",
            Category= new Category(){Articles=new List<Article>(),Name="abc"},
            Comments=new List<Comment>(){},
            Tags = new List<Tag>(){}
            },
            
            new Article{
            Id = 2,
            Title = "Artykul 2",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now,
            Authors = new Author(){FirstName="asada",LastName="asdas",ID=1},
            Lead = "",
            Category= new Category(){Articles=new List<Article>(),Name="abc"},
            Comments=new List<Comment>(){},
            Tags = new List<Tag>(){}
            },
            
            new Article{
            Id = 3,
            Title = "Artykul 3",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now,
            Authors = new Author(){FirstName="asada",LastName="asdas",ID=1},
            Lead = "",
            Category= new Category(){Articles=new List<Article>(),Name="abc"},
            Comments=new List<Comment>(){},
            Tags = new List<Tag>(){}
            },
            
        
  
        };
        return View(articles[id-1]);
    }
}