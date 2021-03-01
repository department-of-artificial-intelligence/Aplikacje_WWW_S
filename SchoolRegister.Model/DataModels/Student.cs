using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.BLL.DataModels
{
    public class Student: User
    {
        public IList<Grade> Grades { get; set;}
        public double AverageGrade => Grades == null || Grades.Count == 0 ? 0.0d : Math.Round(Grades.Average(n => (int)n.GradeValue), 2);
        public IDictionary<string, double> AverageGradePerSubject =>
        Grades == null ? new Dictionary<string, double>():
        Grades.GroupBy(n => n.Subject.Name).Select(n => new {SubjectName = n.Key, Average = Math.Round(n.Average(m => (int)m.GradeValue), 1)})
        .ToDictionary(m => m.SubjectName, m => m.Average);
        public IDictionary<string, List<GradeScale>> GradesPerSubject =>
        Grades == null? new Dictionary<string, List<GradeScale>>():
        Grades.GroupBy(n => n.Subject.Name).Select(n => new {SubjectName = n.Key, GradeList = n.Select(m => m.GradeValue).ToList()})
        .ToDictionary(m => m.SubjectName, m => m.GradeList);
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public Parent Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
