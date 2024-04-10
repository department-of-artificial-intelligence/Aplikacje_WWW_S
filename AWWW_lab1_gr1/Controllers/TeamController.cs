using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class TeamController : Controller
{
    private readonly MyDbContext _context;

    public TeamController(MyDbContext context)
    {
        _context = context;
    }
     public IActionResult Index()
        {
            var teams = _context.Teams.
        Include(team => team.League).
        ToList();
    return View(teams);


        }

        public IActionResult Add()
        {
            var teams = _context.Teams.ToList();
            var teamsList = new List<SelectListItem>();
            foreach (var t in teams)
            {
                string text = t.Name + "," + t.Country + "," + t.City + "," + t.FoundingDate + "," + t.League;
                string id = t.Id.ToString();
                teamsList.Add(new SelectListItem(id,text));
            }
            ViewBag.teamsList = teamsList;
            
           return View();
        }

        [HttpPost]
        public IActionResult Add(Article article, List<int> tags)
        {
            if (ModelState.IsValid)
            {

                article.CreationDate = DateTime.Now;
                //foreach (var tag in tags)
                //{
                //    var existingTag = _dbContext.Tags.FirstOrDefault(t => t.Id == tag);
                //    if (existingTag != null)
                //        article.Tags.Add(existingTag);
                //
                //}
                var articleTags = _context.Tags.Where(t => tags.Contains(t.Id)).ToList();
                article.Tags = articleTags;


                var author = _context.Authors.FirstOrDefault(a => a.Id == article.AuthorId);
                if (author == null)
                {
                    return View("Error");

                }
                article.Author = author;


                _context.Articles.Add(article); //Repository.AddArticle(article);

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

                return View("Added", article);
            }
            return View("Error");
        }
     
}