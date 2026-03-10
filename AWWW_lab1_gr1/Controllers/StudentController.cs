using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var students = new List<Student>
            {
                new Student{
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Drzewicki",
                },
                new Student{
                    Id = 2,
                    FirstName = "Piotr",
                    LastName = "Gawryluk"
                },
                new Student{
                    Id = 3,
                    FirstName = "Wiktoria",
                    LastName = "Matysiak"
                }
            };
            return View(students[id - 1]);
        }
    }
}