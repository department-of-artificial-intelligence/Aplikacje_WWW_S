using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace Kolokwium.Controllers
{
    public class BookController : Controller
    {

        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Libraries = new SelectList(_context.Libraries, "Id", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            //ViewBag.Authors = _context.Authors.ToList();

            return View();
        }

        public IActionResult Edit(int id)
        {
            //var book = _context.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == id);
            var book = _context.Books.Find(id);

            ViewBag.Libraries = new SelectList(_context.Libraries, "Id", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            //ViewBag.Authors = _context.Authors.ToList(); To jest do tych wielu

            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Book book)//int[] selectedAuthors
        {
            //book.Authors = _context.Authors.Where(a => selectedAuthors.Contains(a.Id)).ToList();
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Book book)//int[] selectedAuthors
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Libraries = new SelectList(_context.Libraries, "Id", "Name"); //jak masz z listy to jeszcze to dajesz  a jak checkboxy to pewnie to //ViewBag.Authors = _context.Authors.ToList();
                ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
                return View(book);
            }
            //var existing = _context.Books.Include(_b => _b.Authors).FirstOrDefault(b => b.Id == book.Id);
            var existing = _context.Books.FirstOrDefault(b => b.Id == book.Id);

            existing.Title = book.Title;
            existing.Price = book.Price;
            existing.LibraryId = book.LibraryId;
            existing.AuthorId = book.AuthorId;
            //existing.Authors = _context.Authors.Where(a => selectedAuthors.Contains(a.Id)).ToList();


            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
