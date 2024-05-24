using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Grade
	{
		public DateTime DateOfIssue { get; set; } = DateTime.Now;
		public GradeScale GradeValue { get; set; }

		public int SubjectId { get; set; }
		public  virtual Subject Subject { get; set; } = null!;

		public int StudentId { get; set; }
		public  virtual Student Student { get; set; } = null!;

	}
}