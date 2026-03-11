using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var students = Student.GetStudents();

            var student = students.FirstOrDefault(s => s.Id == id);

            return View(student);
        }
    }
}