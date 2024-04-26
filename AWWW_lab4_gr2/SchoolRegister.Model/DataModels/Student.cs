using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Student : User
	{
		public int? GroupId { get; set; }
		public Group Group { get; set; } = null!;

		public IList<Grade> Grades { get; set; } = new List<Grade>();
		
		public int? ParentId { get; set; }
		public Parent Parent { get; set; } = null!;

		public double AverageGrade
		{
			get
			{
				return Grades.Average(g => (float)g.GradeValue);
			}
		}

		public IDictionary<string, double> AverageGradePerSubject
		{
			get
			{
				var averageGradePerSubject = new Dictionary<string, double>();
				var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
				foreach (var group in groupedGrades)
				{
					averageGradePerSubject.Add(group.Key, group.Average(g => (float)g.GradeValue));
				}
				return averageGradePerSubject;
			}
		}

		public IDictionary<string, List<GradeScale>> GradesPerSubject
		{
			get
			{
				var gradesPerSubject = new Dictionary<string, List<GradeScale>>();
				var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
				foreach (var group in groupedGrades)
				{
					gradesPerSubject.Add(group.Key, group.Select(g => g.GradeValue).ToList());
				}
				return gradesPerSubject;
			}
		}
	}
}
