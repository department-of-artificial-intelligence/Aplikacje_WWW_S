using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
public class StudentController:Controller{

public IActionResult Students(){
    return View();
}


public IActionResult Index(int itemid=1){

var students = new List<Student>{


new Student{
Id=1,
FirstName="Marson",
LastName="Kurek",
IndexNr="101743",
DateOfBirth=DateTime.Now,
FieldOfStudy="PAI"
},
new Student{
    Id=2,
    FirstName="Mistrz",
    LastName="Bambik",
    IndexNr="462891",
    DateOfBirth=DateTime.Now,
    FieldOfStudy="AI"
},
new Student{
    Id=3,
    FirstName="Master",
    LastName="Bambik",
    IndexNr="212891",
    DateOfBirth=DateTime.Now,
    FieldOfStudy="AI"
}
};
return View(students[itemid-1]);
}
}