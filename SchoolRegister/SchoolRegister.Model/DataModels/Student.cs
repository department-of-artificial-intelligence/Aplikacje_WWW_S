namespace SchoolRegister.Model.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Student : User
{
    public int? GroupId { get; set; }
    public Group Group { get; set; }
    public IList<Grade> Grades { get; set; }
    public int? ParentId { get; set; }
    public Parent Parent { get; set; }

    public double AverageGrade
    {
        get
        {
            if (Grades == null || Grades.Count == 0)
                return 0.0;

            double sum = Grades.Sum(g => (int)g.GradeValue);
            return sum / Grades.Count; 
        }
    }

    public IDictionary<string, double> AverageGradePerSubject
    {
        get
        {
            if (Grades == null || Grades.Count == 0)
                return new Dictionary<string, double>();

            return Grades
                .GroupBy(g => g.Subject.Name)
                .ToDictionary(
                    group => group.Key,
                    group => group.Average(g => (int)g.GradeValue)
                );
        }
    }

    public IDictionary<string, List<GradeScale>> GradesPerSubject
    {
        get
        {
            if (Grades == null || Grades.Count == 0)
                return new Dictionary<string, List<GradeScale>>();

            return Grades
                .GroupBy(g => g.Subject.Name)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(g => g.GradeValue).ToList()
                );
        }
    }

    public Student() { }
}
