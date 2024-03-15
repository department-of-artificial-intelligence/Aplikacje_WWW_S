using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

public class StudentController : Controller
{
  private List<Student> students = new List<Student> {
      new Student(1,"Kacper", "Nowak", 123456,DateTime.Now, "IT" ),
      new Student(2,"Lorem", "Ipsum", 123123,DateTime.Now, "WZ" ),
      new Student(3,"Jon", "Snow", 654321,DateTime.Now, "Brak danych" ),
  };

  public IActionResult Index()
  {
    ViewBag.TotalStudents = students.Count();
    ViewBag.students = students;
    return View();
  }

  public IActionResult Students(int id = 1)
  {
    return View(students[id - 1]);
  }
  
}