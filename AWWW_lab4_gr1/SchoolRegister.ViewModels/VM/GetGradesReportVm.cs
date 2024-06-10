using SchoolRegister.Model.DataModels; 

namespace SchoolRegister.ViewModels.VM;

public class GetGradesReportVm {

    public int? ParentId {get; set;}

    public int StudentId {get; set;}
    public string StudentName {get; set;}
}