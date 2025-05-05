namespace SchoolRegister.Model.DataModels;

public class Grade
{
    public DateTime DateOfIssue {get; set;} = DateTime.Now;

    public GradeScale GradeValue {get; set;}
    
    public int SubjectId {get; set;}
    public Subject Subject {get; set;} = null!;

    public int StudentIt {get; set;}
    public Student Student {get; set;} = null!;

    public Grade() {}
}