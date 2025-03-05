using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        double AverageGrade { get; }
        IDictionary<string,double> AverageGradePerSubject { get; }
        IList<Grade> Grades{ get; set; }
        IDictionary<string, List<GradeScale>> GradePerSubject { get; }
        Group Group { get; set; }
        int? GroupId { get; set; }
        Parent Parent { get; set; }
        int? ParentId { get; set; }
    }
}