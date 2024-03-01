using Microsoft.AspNetCore.Mvc;

public class StudentsController : Controller {
    List<Student>students = new List<Student> {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", IndexNr = "12345", DateOfBirth = DateTime.Now, FieldOfStudy = "Computer Science" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Doe", IndexNr = "54321", DateOfBirth = DateTime.Now, FieldOfStudy = "Computer Science" },
            new Student { Id = 3, FirstName = "Alice", LastName = "Smith", IndexNr = "67890", DateOfBirth = DateTime.Now, FieldOfStudy = "Computer Science" }
        };
    public IActionResult Index() {
         

        return View(students);
    }
}
