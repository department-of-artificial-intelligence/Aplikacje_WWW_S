using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels{
    public class Student : User{
        public Group Group { get; set; } = null!;
        public int? GroupId {get; set;}

        public IList<Grade> Grades { get; set; } = new List<Grade>();

        public Parent Parent { get; set; } = null!; 
        public int? ParentId { get; set; }

        public double AverageGrade
        {
            get
            {
                return Grades.Average(g =>(float)g.GradeValue);
            }
        }

        public IDictionary<string, double> AverageGradePerSubject
        {
            get
            {
                var averageGradePerSubject = new Dictionary<string, double>();
                var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
                foreach(var group in groupedGrades)
                {
                    AverageGradePerSubject.Add(group.Key, group.Average(g =>(float)g.GradeValue));
                }
                return averageGradePerSubject;

            }
        }
        public IDictionary<string, List<GradeScale>> GradesPerSubject
        {
            get
            {
                var GradesPerSubject = new Dictionary<string, List<GradeScale>>();
                var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
                foreach(var group in groupedGrades)
                {
                    GradesPerSubject.Add(group.Key, group.Select(g => g.GradeValue).ToList());
                }
                return GradesPerSubject;
            }
        }
    }
}