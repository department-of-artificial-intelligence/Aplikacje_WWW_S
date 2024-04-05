using AWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
  private List<Student> students = new List<Student> {
      new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", IndexNr = 123123, DateOfBirth = new DateTime(2000, 1, 1), FieldOfStudy = "Computer Science" },
      new Student { Id = 2, FirstName = "Anna", LastName = "Nowak", IndexNr = 234234, DateOfBirth = new DateTime(2001, 3, 15), FieldOfStudy = "Physics" },
      new Student { Id = 3, FirstName = "Adam", LastName = "Wieczorek", IndexNr = 345345, DateOfBirth = new DateTime(1999, 8, 20), FieldOfStudy = "Mathematics" }
    };

  public IActionResult Index()
  {
    ViewBag.students = students;
    return View();
  }

  public IActionResult Show(int id = 1)
  {
    return View(students[id - 1]);
  }
}