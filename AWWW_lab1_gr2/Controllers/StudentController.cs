using Microsoft.AspNetCore.Mvc;
public class StudentController : Controller
{
    public IActionResult Student(int id)
    {
        return Index(id);
    }
    public IActionResult Index(int id)
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = 12345,
                DateOfBirth = new DateOnly(1999, 1, 1),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNr = 54321,
                DateOfBirth = new DateOnly(1998, 2, 2),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Kowalski",
                IndexNr = 67890,
                DateOfBirth = new DateOnly(1997, 3, 3),
                FieldOfStudy = "Computer Science"
            },
        };
        if (id == 0)
        {
            return View(students);
        }
        return View(students[id - 1]);
    }
}