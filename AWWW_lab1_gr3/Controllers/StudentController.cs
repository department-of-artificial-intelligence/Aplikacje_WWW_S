using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var Studenci = StudentRepository.Students;
        return View(Studenci[id - 1]);
    }
    public IActionResult Liststudent()
    {
        var Studenci = StudentRepository.Students;
        return View(Studenci);
    }
}