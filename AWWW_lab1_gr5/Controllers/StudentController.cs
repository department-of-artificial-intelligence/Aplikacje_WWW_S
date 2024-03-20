using AWWW_lab1_gr5;
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
                FirstName = "Dominik",
                LastName = "Nowak",
                IndexNr = 133525,
                DateOfBirth = new DateOnly(2000, 4, 04),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Stanisław",
                LastName = "Mormon",
                IndexNr = 133432,
                DateOfBirth = new DateOnly(2000, 1, 22),
                FieldOfStudy = "Informatyka"
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






