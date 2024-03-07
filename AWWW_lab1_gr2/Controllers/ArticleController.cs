
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using AspNetCore;

public class ArticleController : Controller{

    public IActionResult Index(){
        ViewBag.Title = "Article";
        return View();

    }

    public IActionResult MyView(){
        throw new NotImplementedException();
    }

    public IActionResult Index(int id=1){
        var articles =new List<Article>
        {
            new Article{
            Id=1,
            Title="Artykul 1",
            Content="lorem Ipsum..",
            CreationDate=DateTime.Now
            },
            new Article{
            Id=2,
            Title="Artykul 2",
            Content="lorem Ipsum..",
            CreationDate=DateTime.Now
            },
            new Article{
            Id=3,
            Title="Artykul 3",
            Content="lorem Ipsum..",
            CreationDate=DateTime.Now
            }
            
        };
        return View(articles[id-1]);
    }
}