using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Student: User
    {
        public virtual Group? Group { get; set; }
        [ForeignKey("Group")]
        public int? GroupId {get; set;}
        public virtual IList<Grade> Grades {get; set;} = default!;
        public virtual Parent? Parent { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId {get; set;}
        [NotMapped]
        public double AverageGrade {
            get { return Grades.Sum(g => (double)g.GradeValue) / (Grades.Count()); }
        }

        [NotMapped]
        public IDictionary<string, double> AverageGradePerSubject {
            get { 
                return Grades
                    .GroupBy(g => g.Subject.Name)
                    .Select(g => new { SubjectName = g.Key, AvgGrade = Math.Round(g.Average(avg => (int)avg.GradeValue), 1) })
                    .ToDictionary(
                        avg => avg.SubjectName,
                        avg => avg.AvgGrade
                    );
            }
        }
        [NotMapped]
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