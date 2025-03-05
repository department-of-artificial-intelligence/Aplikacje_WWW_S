using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        string Description { get; set; }
        IList<Grade> Grades { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        IList<SubjectGroup> SubjectGroups { get; set; }
        Teacher Teacher { get; set; }
        int? TeacherId { get; set; }
    }
}