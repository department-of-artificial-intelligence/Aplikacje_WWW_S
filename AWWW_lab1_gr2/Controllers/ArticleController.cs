using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ArticleController:Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 
    public ArticleController(DatabaseContext context, ILogger logger) {
        _context = context; 
        _logger = logger; 
    }
    public IActionResult Index() {

        ViewBag.Title="Artykuly"; 
        var articles = _context.Articles.Include(a=> a.Author).Include(a => a.Category).Include(a => a.Tags); 

        
        return View(articles); 
    }

    public IActionResult Details(int id) {
        try {
            var article = _context.Articles.Include(a => a.Comments).FirstOrDefault(a => a.ArticleId == id); 
            if(article == null) throw new Exception("nie znaleziono artykulu"); 
            return View(article); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }


    public IActionResult Add() {
        ViewBag.Title = "Dodawanie artykułu"; 
        try {
            ViewBag.Authors = _context.Authors.Select(a => new SelectListItem(a.FirstName + " "+ a.LastName, a.AuthorId.ToString() )); 
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.CategoryId.ToString()));
            ViewBag.Tags = _context.Tags.Select(t => new SelectListItem(t.Name, t.TagId.ToString())); 
            return View(); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpPost]
    public IActionResult Add(Article article, List<int> selectedTagIds) {
        ModelState.Remove("Author"); 

        if(!ModelState.IsValid){
            throw new Exception("cos nie dziala modelstate"); 
        }
        try {
            article.Author = _context.Authors.Find(article.AuthorId);  
            article.Category = _context.Categories.Find(article.CategoryId); 
            article.Tags = _context.Tags.Where(t => selectedTagIds.Contains(t.TagId)).ToList();  

            _context.Articles.Add(article); 
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index)); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }

    }

    [HttpPost]
    public IActionResult Delete(int id){
        try {
            var article = _context.Articles.Find(id); 
            if(article == null) throw new Exception("nie znaleziono artykulu do usuniecia"); 
            _context.Articles.Remove(article); 
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index)); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet] 
    public IActionResult Edit(int id){
        try {
            var articleToEdit = _context.Articles.Find(id); 
            if(articleToEdit == null) throw new Exception ("nie znaleziono artykulu do edycji"); 
            ViewBag.Authors = _context.Authors.Select(a => new SelectListItem(a.FirstName + " " + a.LastName, a.AuthorId.ToString()));  
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.CategoryId.ToString())); 
            ViewBag.Tags = _context.Tags.Select(t => new SelectListItem(t.Name, t.TagId.ToString())); 
            return View(articleToEdit); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpPost]
    public IActionResult Edit(Article article, List<int> selectedTagIds){
        try {
            ViewBag.Title = article.ArticleId; 
            if(!ModelState.IsValid){
                throw new Exception("modelstate error"); 
            }   
            var existingArticle = _context.Articles.Include(a => a.Category).Include(a => a.Tags).Include(a => a.Comments).Include(a => a.Match).FirstOrDefault(a => a.ArticleId == article.ArticleId); 
            if(existingArticle == null) throw new Exception("nie znaleziono artykulu"); 
            existingArticle.Title = article.Title; 
            existingArticle.Content = article.Content; 
            existingArticle.CreationDate = article.CreationDate; 
            existingArticle.AuthorId = article.AuthorId;
            existingArticle.Author = article.Author; 
            existingArticle.CategoryId = article.CategoryId; 
            existingArticle.Category = _context.Categories.Find(existingArticle.CategoryId); 
            existingArticle.Tags = _context.Tags.Where(t => selectedTagIds.Contains(t.TagId)).ToList(); 

            _context.SaveChanges(); 

            return RedirectToAction(nameof(Index)); 

        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

}