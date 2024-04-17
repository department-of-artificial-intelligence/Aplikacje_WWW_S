using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public IList<Grade> Grades { get; set; }
        public Parent Parent { get; set; }
        public int ParentId {get; set;  }
        public double AverateGrade { get;}
        public IDictionary<string, double> {get;}
        public IDictionary<string, List<GradeScale>> {get;}
    }
}