using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM;

public class GradeVm
{
  public int StudentId { get; set; }
  public int SubjectId { get; set; }
  public GradeScale GradeValue { get; set; }
  public int TeacherId { get; set; }
  public DateTime DateOfIssue { get; set; }
}