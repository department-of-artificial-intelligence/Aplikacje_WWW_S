using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class SubjectGroup
	{
		public int SubjectId { get; set; }
		public Subject Subject { get; set; } = null!;

		public int GroupId { get; set; }
		public Group Group { get; set; } = null!;
	}
}
