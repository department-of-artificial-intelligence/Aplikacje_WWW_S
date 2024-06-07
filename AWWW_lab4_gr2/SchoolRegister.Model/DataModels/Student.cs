using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels{
    public class Student : User{
        public  virtual Group Group { get; set; } = null!;
        [ForeignKey("Group")]
        public int? GroupId {get; set;}
        public virtual IList<Grade> Grades { get; set; } = new List<Grade>();

        public virtual Parent Parent { get; set; } = null!;

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        
        [NotMapped]
        public double AverageGrade
        {
            get
            {
                return Grades.Average(g =>(float)g.GradeValue);
            }
        }

        [NotMapped]
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
        [NotMapped]
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