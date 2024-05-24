using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public virtual Group? Group { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public virtual IList<Grade> Grades { get; set; } = default!;
        public virtual Parent? Parent { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        [NotMapped]
        public double AverageGrade
        {
            get
            {
                if (Grades == null || Grades.Count == 0)
                    return 0;
                return Grades.Average(g => (double)g.GradeValue);
            }
        }

        [NotMapped]
        public IDictionary<string, double> CalculateAverageGradePerSubject
        {
            get
            {
                var subjectAverages = new Dictionary<string, double>();
                var subjectGroups = Grades.GroupBy(g => g.Subject.Name);

                foreach (var group in subjectGroups)
                {
                    subjectAverages[group.Key] = group.Average(g => (double)g.GradeValue);
                }

                return subjectAverages;
            }
        }

        public IDictionary<string, double> CalculateAllAverageGradesPerSubject()
        {
            var averageGradesPerSubject = new Dictionary<string, double>();

            var subjects = Grades.Select(g => g.Subject.Name).Distinct();
            foreach (var subject in subjects)
            {
                averageGradesPerSubject[subject] = CalculateAverageGradePerSubject[subject];
            }

            return averageGradesPerSubject;
        }

        public IDictionary<string, List<GradeScale>> GetGradesPerSubject()
        {
            var gradesPerSubject = new Dictionary<string, List<GradeScale>>();

            foreach (var grade in Grades)
            {
                if (!gradesPerSubject.ContainsKey(grade.Subject.Name))
                {
                    gradesPerSubject[grade.Subject.Name] = new List<GradeScale>();
                }
                gradesPerSubject[grade.Subject.Name].Add(grade.GradeValue);
            }

            return gradesPerSubject;
        }
    }
}
