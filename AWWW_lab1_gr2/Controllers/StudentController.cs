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
                FirstName = "Adam",
                LastName = "Kowalski",
                IndexNr = 1001,
                DateOfBirth = new DateOnly(2000, 5, 15),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Ewa",
                LastName = "Nowak",
                IndexNr = 1002,
                DateOfBirth = new DateOnly(2001, 8, 22),
                FieldOfStudy = "Technologia Informacyjna"
            },
            new Student
            {
                Id = 3,
                FirstName = "Michał",
                LastName = "Wiśniewski",
                IndexNr = 1003,
                DateOfBirth = new DateOnly(1999, 12, 10),
                FieldOfStudy = "Inżynieria Oprogramowania"
            },
        };

        if (id == 0)
        {
            return View(students);
        }

        return View(students[id - 1]);
    }
}






