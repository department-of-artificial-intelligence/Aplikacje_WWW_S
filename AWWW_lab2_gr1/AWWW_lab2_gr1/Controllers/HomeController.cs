using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            var students = Student.GetStudents();
            return View(students);
        }
    }
}
