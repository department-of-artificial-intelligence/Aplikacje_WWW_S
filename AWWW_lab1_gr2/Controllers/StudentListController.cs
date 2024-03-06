using System.Text.Json;
using System.Text.Json.Serialization;
using AWWW_lab1_gr2.Models; 
using Microsoft.AspNetCore.Mvc;

public class StudentListController: Controller {

    private List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Szymon",
                LastName = "Marciniak",
                IndexNr = 1111,
                DateOfBirth = new DateTime(1990, 1, 1),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Kuba",
                LastName = "Nowak",
                IndexNr = 1112,
                DateOfBirth = new DateTime(1991, 2, 2),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 3,
                FirstName = "Anna",
                LastName = "Kowalska",
                IndexNr = 1113,
                DateOfBirth = new DateTime(1992, 3, 3),
                FieldOfStudy = "Matematyka"
            }
            // Dodaj więcej studentów według potrzeb
        };
    }
    public IActionResult Index(){
        ViewBag.Title = "Studenci"; 

        var students = GetStudents(); 

        TempData["Students"] = JsonSerializer.Serialize(students); 

        return View(students); 
    }

    public IActionResult Details(int id){
        var students = GetStudents(); 
        var student = students.FirstOrDefault(s => s.Id == id); 

        if(student == null){
            return NotFound(); 
        }
        ViewBag.Title = "Szczegóły studenta"; 
        return View(student); 
    }
} 