using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class TagController : Controller {

        private readonly MyDbContext _dbContext;

        public TagController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var tags = _dbContext.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add() {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Tag tag){
            if (tag == null){
                return View("Error");
            }
            _dbContext.Tags.Add(tag);
            try {
                _dbContext.SaveChanges();
            } catch (Exception ex) {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
