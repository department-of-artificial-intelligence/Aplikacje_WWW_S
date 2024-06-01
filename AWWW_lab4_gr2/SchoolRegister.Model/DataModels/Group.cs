using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public virtual IList<Student> Students { get; set; } = new List<Student>();
		public virtual IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
	}
}
