using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers;

public class StudentController : Controller{
    
        private static List<Student> students=new List<Student>{
            new Student {Id=1, FirstName="Robert", LastName="Kowal", IndexNr=123, DateOfBirth=new DateTime(2009,12,1), FieldOfStudy="Fizyka" },
            new Student {Id=1, FirstName="Robert", LastName="Nowak", IndexNr=456, DateOfBirth=new DateTime(2004,09,30), FieldOfStudy="Chemia" },
            new Student {Id=3, FirstName="Anna", LastName="Kowalska", IndexNr=789, DateOfBirth=new DateTime(1999,08,31), FieldOfStudy="Geografia" }
        
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