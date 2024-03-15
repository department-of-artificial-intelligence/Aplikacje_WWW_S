using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers{
public class ArticleController:Controller
{

   private readonly MeBdContext _dbContext;

        public ArticleController(MeBdContext dbContext)
        {
            _dbContext = dbContext;
        }
    public IActionResult Index(int id=1)
    {
       var articles = new List<Article> 
        { 
            new Article{ 
            Id = 1, 
            Title = "Artykul 1", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now,
            Authors = new Author(){Articles=new List<Article>(),FirstName="asada",LastName="asdas",Id=2},
         Category= new Category(){Articles=new List<Article>(),Id=2,Name="sadsa"},
         Comments=new List<Comment>(){},
         Tags = new List<Tag>(){}                   
            }, 
            new Article{ 
            Id = 2, 
            Title = "Artykul 2", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now,Authors = new Author(){Articles=new List<Article>(),FirstName="asada",LastName="asdas",Id=2},
         Category= new Category(){Articles=new List<Article>(),Id=2,Name="sadsa"},
         Comments=new List<Comment>(){},
         Tags = new List<Tag>(){}
            }, 
            new Article{ 
            Id = 3, 
            Title = "Artykul 3", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now,
            Authors = new Author(){Articles=new List<Article>(),FirstName="asada",LastName="asdas",Id=2},
         Category= new Category(){Articles=new List<Article>(),Id=2,Name="sadsa"},
         Comments=new List<Comment>(){},
         Tags = new List<Tag>(){} 
            } 
         
   
        };

        return View(articles[id-1]);
    }
}}