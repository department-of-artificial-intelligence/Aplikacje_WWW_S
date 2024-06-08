
namespace SchoolRegister.ViewModels.VM; 

public class GradesReportVm {
    // public int StudentId {get; set;} 
    public string StudentName {get; set;}

    public IList<GradeVm> Grades {get; set;}
}