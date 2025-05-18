namespace SchoolRegister.ViewModels.VM;
public class GradesReportVm
{
    public string StudentName {get; set;} = null!;
    public IList<GradeVm>? Grades;
}