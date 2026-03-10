using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using System;

namespace AWWW_lab1_gr1.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index(int id=1)
		{
			var students = new List<Student>
			{
				new Student
				{
					Id = 1,
					FirstName = "Radosław",
					LastName = "Kawa",
					IndexNr = 138248,
					DateOfBirth = new DateTime(2003,7,15),
					FieldOfStudy = "IT"
				},
				new Student
				{
					Id = 2,
					FirstName = "Bartłomiej",
					LastName = "Latocha",
					IndexNr = 111111,
					DateOfBirth = new DateTime(2003,5,10),
					FieldOfStudy = "IT"
				},
				new Student
				{
					Id = 3,
					FirstName = "Paweł",
					LastName = "Sczypior",
					IndexNr = 321123,
					DateOfBirth = new DateTime(2003,4,23),
					FieldOfStudy = "PE"
				}
			};
			return View(students[id-1]);
		}
	}
}
