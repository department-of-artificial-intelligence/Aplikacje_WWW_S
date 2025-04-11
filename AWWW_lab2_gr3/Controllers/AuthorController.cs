using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr3.Controllers{

    public class AuthorController : Controller
    {

    
        private readonly AppDbContext _dbContext;

        public AuthorController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title="Autorzy";
            var authors = _dbContext.Authors.ToList();
            return View("Index",authors);

        }

        [HttpGet]

        public IActionResult Create()
        {
           return View(new Author());
    
        }


        [HttpPost]

        public IActionResult Create(Author aut)
        {
                try
                {
                    _dbContext.Authors.Add(aut);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać Autora: " + e.Message);
                }

                return RedirectToAction("Index");
            
        }
}}