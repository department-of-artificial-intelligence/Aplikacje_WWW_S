
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM; 

public class AddGradeToStudentVm {
    public int TeacherId {get; set;}
    public int StudentId {get; set;}
    
    public GradeVm Grade {get; set;}
}