using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController:Controller {
    public IActionResult Index(int id=1) {
        var students = new List<Student>{
            new Student{
                Id=1, 
                FirstName = "Szymon", 
                LastName = "Marciniak", 
                IndexNr = 1111,
                DateOfBirth = DateTime.Now, 
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id=2, 
                FirstName = "Kuba", 
                LastName = "Nowak", 
                IndexNr = 1112,
                DateOfBirth = DateTime.Now, 
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id=3, 
                FirstName = "Szymon", 
                LastName = "Marciniak", 
                IndexNr = 1113,
                DateOfBirth = DateTime.Now, 
                FieldOfStudy = "Informatyka"
            },
            

        } 
    }
}