using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers{
    public class StudentController :Controller{
        List<Student> studenci = new List<Student>
            {
                new Student{
                    Id = 1,
                    FirstName = "Kacper",
                    LastName = "Z",
                    IndexNr = 100,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Programowanie Stron Internetowych"
                },
                new Student{
                    Id = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    IndexNr = 101,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Inżynieria Oprogramowania"
                },
                new Student{
                    Id = 3,
                    FirstName = "Kuba",
                    LastName = "Brzęczyszczykiewicz",
                    IndexNr = 102,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Sieci Komputerowe"
                }
            };
        public IActionResult Index(){
            return View(studenci);
        }
        public IActionResult Details(int id=1){
            return View(studenci[id-1]);
        }
    }
}