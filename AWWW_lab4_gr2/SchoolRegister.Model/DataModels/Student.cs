using System;
namespace SchoolRegister.Model.DataModels;
public class Student
{
    public Group Group { get; set; } = null!;
    public int? GroupId { get; set; }
    public IList<Grade> Grades { get; set; } = new List<Grade>();
    public Parent Parent { get; set; } = null!;
    public int? ParentId { get; set; }
    public IDictionary<string, double> AverageGradePerSubject
    {
        get
        {
            var averageGradePerSubject = new Dictionary<string, double>();
            var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
            foreach (var group in groupedGrades)
            {
                averageGradePerSubject.Add(group.Key, group.Average(g => (float)g.GradeValue));
            }
            return averageGradePerSubject;
        }
    }
    public IDictionary<string, List<GradeScale>> GradesPerSubject
    {
        get
        {
            var gradesPerSubject = new Dictionary<string, List<GradeScale>>();
            var groupedGrades = Grades.GroupBy(g => g.Subject.Name);
            foreach (var group in groupedGrades)
            {
                gradesPerSubject.Add(group.Key, group.Select(g => g.GradeValue).ToList());
            }
            return gradesPerSubject;
        }
    }
    public double AverageGrade
    {
        get
        {
            return Grades.Average(g => (float)g.GradeValue);
        }
    }
}