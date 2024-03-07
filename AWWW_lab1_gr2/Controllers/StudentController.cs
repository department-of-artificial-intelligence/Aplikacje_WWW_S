using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers;

public class StudentController : Controller{
    
        private static List<Student> students=new List<Student>{
            new Student {Id=1, FirstName="Khrystyna", LastName="Stepan", IndexNr=123, DateOfBirth=new DateTime(2003,06,10), FieldOfStudy="Informatyka" },
            new Student {Id=1, FirstName="Wolodymyr", LastName="Moroz", IndexNr=456, DateOfBirth=new DateTime(1996,10,11), FieldOfStudy="Matematyka" },
            new Student {Id=3, FirstName="Adam", LastName="Nowak", IndexNr=789, DateOfBirth=new DateTime(2000,09,30), FieldOfStudy="Fizyka" }
        
        };
    public IActionResult Index(){
        return View(students);
    }

    public IActionResult StudentInfo(int id){
        var student=students.FirstOrDefault(s=>s.Id==id);
        if(student==null){
            return NotFound();
        }
        else {
            return View(student);
        }
            
    }
}