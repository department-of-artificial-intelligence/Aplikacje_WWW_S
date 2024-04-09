using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr2.Controllers
{
	public class CommentController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CommentController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index(int? id)
		{
			var comments = _context.Comments.Where(c => c.ArticleId == id)
				.ToList();

			return View(comments);
		}

		public IActionResult Add(int? id)
		{
			ViewBag.ArticleId = id;
            return View();
        }

		[HttpPost]
		public IActionResult Add(Comment comment)
		{
			comment.Id = 0;
			_context.Comments.Add(comment);
			_context.SaveChanges();

			return RedirectToAction("Show", "Article", new { id = comment.ArticleId });
		}

		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comment = _context.Comments
				.FirstOrDefault(c => c.Id == id);

			return View(comment);
		}

        [HttpPost]
        public IActionResult Edit(Comment comment)
        {

            var commentToUpdate = _context.Comments
                .FirstOrDefault(c => c.Id == comment.Id);

            if (commentToUpdate != null)
            {
                commentToUpdate.Title = comment.Title;
                commentToUpdate.Content = comment.Content;

                _context.SaveChanges();
            }

            return RedirectToAction("Show", "Article", new { id = commentToUpdate.ArticleId });
        }

        public IActionResult Delete(int? id)
        {
            var comment = _context.Comments.Find(id);
			var artId = comment.ArticleId;
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

            return RedirectToAction("Show", "Article", new { id = artId });
        }
    }
}
