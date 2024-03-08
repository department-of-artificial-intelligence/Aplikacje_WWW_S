using Microsoft.AspNetCore.Mvc;
namespace AWWW_lab1_gr2.Controllers
{
    public class StudenciController
    {
         public IActionResult Index(int id=1)
    {
        var Studenci = new List<Student>
        {
            new Student
            {
                Id=1,
                Firstname="jakub"
            },

//223
        };
       
       return View(Studenci[id-1]);
    }
    }
}