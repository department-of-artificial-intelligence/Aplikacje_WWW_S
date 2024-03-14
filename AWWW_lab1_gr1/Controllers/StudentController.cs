using Microsoft.AspNetCore.Mvc; 
using AWWW_lab1_gr1.Models; 

public class StudentController:Controller
{
    public ActionResult Index(int id=1)
    {
        var student = new List<Student>
        {
            new Student 
            {
                Id = 1, 
                FirstName = "Bob", 
                LastName = "Bobson",
                IndexNr = 1337, 
                DateOfBirth = new DateTime(2004,3,12),
                FieldOfStudy = "Computer science"
            },

            new Student 
            {
                Id = 2, 
                FirstName = "Rayan", 
                LastName = "Gosling",
                IndexNr = 1488, 
                DateOfBirth = new DateTime(2003,2,26),
                FieldOfStudy = "English"
            },

            new Student 
            {
                Id = 3, 
                FirstName = "Bill", 
                LastName = "Wilkins",
                IndexNr = 2289, 
                DateOfBirth = new DateTime(2008,4,2),
                FieldOfStudy = "Math"
            }


        };
        return View(student[id-1]);
    }
}