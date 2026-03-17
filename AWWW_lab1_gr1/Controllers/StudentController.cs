using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index(int id)
		{

            var students = Student.GetStudents();
            return View(students);
        }
	}
}
