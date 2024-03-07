using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller{
    public IActionResult Index(int id=1){
        var students = new List<Student>{
            new Student{
                Id=1,
                FirstName="Name 1",
                LastName="Surname 1",
                IndexNr=111111,
                DateOfBirth=new DateTime(2001,01,01),
                FieldOfStudy="Informatyka"
            },
            new Student{
                Id=2,
                FirstName="Name 2",
                LastName="Surname 2",
                IndexNr=222222,
                DateOfBirth=new DateTime(2002,02,02),
                FieldOfStudy="Matematyka"
            },
            new Student{
                Id=3,
                FirstName="Name 3",
                LastName="Surname 3",
                IndexNr=333333,
                DateOfBirth=new DateTime(2003,03,03),
                FieldOfStudy="Budownictwo"
            }
        };
        return View(students[id-1]);
    }
}