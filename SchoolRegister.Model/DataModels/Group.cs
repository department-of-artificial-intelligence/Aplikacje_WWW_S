using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Group
    {
        int Id { get; set; }
        string Name { get; set; }
        IList<Student> Students { get; set; }
        IList<SubjectGroup> SubjectGroups { get; set; }
    }
}