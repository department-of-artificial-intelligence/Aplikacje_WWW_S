using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{

			var students = new List<Student>
			{
				new Student
				{
					Id=1,
					FirstName="Bartlomiej",
					LastName="Latocha",
					IndexNr=111111,
					DateOfBirth=new DateTime(2003,5,10),
					FieldOfStudy="Informatyka"
				},

				new Student
				{
					Id=2,
					FirstName="Radoslaw",
					LastName="Kawa",
					IndexNr=222222,
					DateOfBirth=new DateTime(2003,7,12),
					FieldOfStudy="Informatyka"
				},

				new Student
				{
					Id=3,
					FirstName="Pawel",
					LastName="Szczypior",
					IndexNr=333333,
					DateOfBirth=new DateTime(2003,2,5),
					FieldOfStudy="Informatyka"
				},
			};

			return View(students);
		}
	}
}
