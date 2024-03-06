using System.Text.Json;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController:Controller {
    public IActionResult Index(int id=1) {
        var studentsJson = TempData["Students"] as string; 
        if (studentsJson != null){
            var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
            return View(students[id-1]); 
        } else {
            return RedirectToAction("Index", "Home"); 
        }
    }
}