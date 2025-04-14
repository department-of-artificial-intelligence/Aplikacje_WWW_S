using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class CommentController : Controller
{
    private readonly OskiDBContext _dbContext;

    public CommentController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var comments = _dbContext.Comment.ToList();
        return View(comments);
    }

}