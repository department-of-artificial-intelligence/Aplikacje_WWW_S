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
                FirstName = "Andrzej",
                LastName = "Andrzejowski",
                IndexNr = 133700,
                DateOfBirth = new DateTime(1989, 03, 15),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Rafał",
                LastName = "Rafałowski",
                IndexNr = 133701,
                DateOfBirth = new DateTime(1999, 05, 26),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 3,
                FirstName = "Kajetan",
                LastName = "Kajetanowicz",
                IndexNr = 133702,
                DateOfBirth = new DateTime(2001, 10, 11),
                FieldOfStudy = "Informatyka"
            },
        };

        if (id == 0)
        {
            return View(students);
        }

        return View(students[id - 1]);
    }
}