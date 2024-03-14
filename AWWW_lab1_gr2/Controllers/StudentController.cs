using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller{
    
    public List<Student> createStudents(){
        var students = new List<Student>{
            new Student{
                Id=1,
                FirstName="Name 1",
                LastName="Surname 1",
                IndexNr=111111,
                DateOfBirth=new DateTime(01/01/2001),
                FieldOfStudy="Informatyka"
            },
            new Student{
                Id=2,
                FirstName="Name 2",
                LastName="Surname 2",
                IndexNr=222222,
                DateOfBirth=new DateTime(02/02/2002),
                FieldOfStudy="Matematyka"
            },
            new Student{
                Id=3,
                FirstName="Name 3",
                LastName="Surname 3",
                IndexNr=333333,
                DateOfBirth=new DateTime(03/03/2003),
                FieldOfStudy="Budownictwo"
            }
        };
        return students;
    }
    
    public IActionResult Index(){
        return View(createStudents());
    }
    
    public IActionResult Details(int id){
        var students = createStudents();
        return View(students[id-1]);
    }
}