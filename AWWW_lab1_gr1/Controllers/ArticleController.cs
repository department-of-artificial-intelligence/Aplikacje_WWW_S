using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
public class ArticleController : Controller
    {
        private readonly MyDbContext _dbContext;

        public ArticleController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id); //Repository.Articles.ToList()[id];
            if (article != null)
            {
                return View(article);
            }
            return View("Error");
        }

        public IActionResult Add()
        {
            var authors = _dbContext.Authors.ToList();
            var authorsList = new List<SelectListItem>();
            foreach (var a in authors)
            {
                string text = a.FirstName + " " + a.LastName;
                string id = a.Id.ToString();
                authorsList.Add(new SelectListItem(text, id));
            }
            ViewBag.authorsList = authorsList;

            var tags = _dbContext.Tags.ToList();
            var tagsList = new List<SelectListItem>();
            foreach (var t in tags)
            {
                string text = t.Name;
                string id = t.Id.ToString();
                tagsList.Add(new SelectListItem(text, id));
            }
            ViewBag.tagsList = tagsList;

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
                var articleTags = _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList();
                article.Tags = articleTags;


                var author = _dbContext.Authors.FirstOrDefault(a => a.Id == article.AuthorId);
                if (author == null)
                {
                    return View("Error");

                }
                article.Author = author;


                _dbContext.Articles.Add(article); //Repository.AddArticle(article);

                try
                {
                    _dbContext.SaveChanges();
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

