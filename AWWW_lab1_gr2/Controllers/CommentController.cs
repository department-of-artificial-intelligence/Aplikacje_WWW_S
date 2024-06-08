using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 


public class CommentController: Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 
    public CommentController(DatabaseContext context, ILogger logger){
        _context = context; 
        _logger = logger; 
    }

    public IActionResult Index() {
        try {
            var comments = _context.Comments; 
            return View(comments); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            throw;  
        }
    }

    [HttpGet]
    public IActionResult Add(int id) {
        try {
            ViewBag.ArticleId = id; 
            return View(); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }
    [HttpPost]
    public IActionResult Add(Comment comment) {
        try {
            if(!ModelState.IsValid) throw new Exception("modelstate error"); 
            comment.Article = _context.Articles.Find(comment.ArticleId); 
            _context.Comments.Add(comment); 
            _context.SaveChanges(); 
            return RedirectToAction("Details","Article", new {id = comment.ArticleId}); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet]
    public IActionResult Delete(int id) {
        try {
            var comment = _context.Comments.Find(id); 
            if(comment == null) throw new Exception("nie znaleziono komentarza - Delete, Comment"); 
            _context.Comments.Remove(comment); 
            _context.SaveChanges(); 
            return RedirectToAction("Details", "Article", new {id = comment.ArticleId}); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet]
    public IActionResult Edit(int id) {
        try{
            var commentToEdit = _context.Comments.Find(id); 
            if(commentToEdit == null) throw new Exception("error, Edit, Comment"); 
            return View(commentToEdit); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpPost]
    public IActionResult Edit(Comment comment){
        try {
            if(!ModelState.IsValid) throw new Exception("modelstate, Edit, Comment"); 
            var existingComment = _context.Comments.Find(comment.CommentId); 
            if(existingComment == null) throw new Exception("error, Edit, Comment"); 
            existingComment.Title = comment.Title; 
            existingComment.Content = comment.Content; 
            _context.SaveChanges(); 
            return RedirectToAction("Details", "Article", new {id = existingComment.ArticleId}); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

}