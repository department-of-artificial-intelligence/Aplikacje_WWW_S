using Microsoft.AspNetCore.Mvc; 
using AWWW_lab1_gr1.Models; 

public class StudentController:Controller
{
    public ActionResult Index(int id=1)
    {
        var students = new List<Student>
        {
            new Student 
            {
                ID = 1, 
                FirstName = "Tola", 
                LastName = "Dub",
                IndexNr = 1345, 
                DateOfBirth = new DateTime(2000,3,12),
                FieldOfStudy = "Math"
            },

            new Student 
            {
                ID = 2, 
                FirstName = "Anna", 
                LastName = "Yon",
                IndexNr = 1245, 
                DateOfBirth = new DateTime(2001,6,21),
                FieldOfStudy = "Engl"
            },

            new Student 
            {
                ID = 3, 
                FirstName = "Lena", 
                LastName = "GolowaCz",
                IndexNr = 1145, 
                DateOfBirth = new DateTime(200,9,1),
                FieldOfStudy = "Engl"
            }


        };
        return View(students[id-1]);
    }
}