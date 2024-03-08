using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class StudentsController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Studenci";
        return View();
    }
}