using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        //Lista
        public IActionResult Index()
        {
            var courses = _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .ToList();

            return View(courses);
        }

        //Create
        public IActionResult Create()
        {
            ViewBag.Instructors = _context.Instructors.ToList();
            return View();
        }

        //CREATE POST
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Student Add do kursu
        public IActionResult AddStudent(int id)
        {
            ViewBag.CourseId = id;
            ViewBag.Students = _context.Students.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(int courseId, int studentId)
        {
            var course = _context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == courseId);

            var student = _context.Students.Find(studentId);

            if (course != null && student != null)
            {
                if (!course.Students.Contains(student))
                {
                    course.Students.Add(student);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        //delete get
        public IActionResult Delete(int id)
        {
            var course = _context.Courses
                .Include(c => c.Instructor)
                .FirstOrDefault(c => c.Id == id);

            return View(course);
        }

        //delete post
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}