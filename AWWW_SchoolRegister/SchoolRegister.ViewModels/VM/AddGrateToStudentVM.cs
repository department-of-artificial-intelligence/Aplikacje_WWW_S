using SchoolRegister.Model.DataModels;

public class AddGradeToStudentVm
{
  public int StudentId { get; set; }
  public int SubjectId { get; set; }
  public GradeScale GradeValue { get; set; }
  public int TeacherId { get; set; }
}