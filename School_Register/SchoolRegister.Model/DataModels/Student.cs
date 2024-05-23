using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student: User
    {
        public Group Group { get; set; }
        public int? GroupId {get; set;}
        public IList<Grade> Grades {get; set;}
        public Parent Parent { get; set; }
        public int? ParentId {get; set;}
        public double AverageGrade {
            get { return Grades.Sum(g => (double)g.GradeValue) / (Grades.Count()); }
        }

        public IDictionary<string, double> AverageGradePerSubject {
            get { 
                return Grades
                    .GroupBy(g => g.Subject.Name)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Average(grade => (double)grade.GradeValue)
                    );
            }
        }
        public IDictionary<string, List<GradeScale>> GradesPerSubject {
            get {
                return Grades
                    .GroupBy(g => g.Subject.Name)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(grade => grade.GradeValue).ToList()
                    );
            }
        }
    }
}