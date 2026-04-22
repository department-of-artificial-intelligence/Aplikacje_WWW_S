using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _context;

        public InstructorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var instructors = _context.Instructors
                .Include(i => i.Courses)
                .ToList();

            return View(instructors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var instructor = _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);

            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);

            //dla picu
            /*if (instructor.Courses.Any())
            {
                return Content("Nie można usunąć instruktora z kursami!");
            }*/ 

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}