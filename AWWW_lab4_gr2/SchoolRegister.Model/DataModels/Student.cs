
namespace SchoolRegister.Model.DataModels{
public class Student : User{
    public Group? Group { get; set; }
    public int? GroupId { get; set; }
    public IList<Grade> Grades { get; set; } = new List<Grade>();
    public Parent? Parent { get; set; }
    public int? ParentId { get; set; }
    public double AverageGrade {
        get{
            return Grades.Average(g=> (float)g.GradeValue);
        }

    }
    public IDictionary<string,double> AverageGradePerSubject {
        get{
            return (IDictionary<string, double>)Grades
                .GroupBy(g=>g.Subject.Name)
                .ToDictionary(group=>group.Key, group=>group.Average(g=>(float)g.GradeValue));

        }
    }
    public IDictionary<string,List<GradeScale>> GradesPerSubject{
        get{
            return (IDictionary<string, List<GradeScale>>)Grades
            .GroupBy(g=>g.Subject.Name)
            .ToDictionary(group=>group.Key,group=>group.Select(g=>g.GradeValue)).ToList();
        }
    }

}
}