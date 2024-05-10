using System.Text.RegularExpressions;

public class Student {
    public Group? Group{ get; set; }   
    public int? GroupId{ get; set; }
    public required IList<Grade> Grades{ get; set; }
    public Parent? Parent{ get; set; }
    public int? ParentId{ get; set; }
    public double AverageGrade {get;set;}
    public IDictionary<string,double>? AverageGradePerSubject{ get;}
     public IDictionary<string, List<GradeScale>>? GradesPerSubject { get; }
}