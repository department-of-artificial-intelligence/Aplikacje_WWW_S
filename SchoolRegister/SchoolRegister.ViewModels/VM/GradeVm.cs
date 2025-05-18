using SchoolRegister.Model.DataModels;
namespace SchoolRegister.ViewModels.VM;
public class GradeVm
{
    public DateTime DateOfIssue {get; set;}
    public GradeScale GradeValue {get; set;}
    public int SubjectId {get; set;}
    public string SubjectName {get; set;} = null!;
    public int StudentId {get; set;}
    public string StudentName {get; set;} = null!;
    public int TeacherId {get; set;}
    public int GetterUserId {get; set;}
}