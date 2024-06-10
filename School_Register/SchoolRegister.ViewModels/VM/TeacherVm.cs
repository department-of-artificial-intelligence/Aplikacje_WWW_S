using SchoolRegister.Model.DataModels; 

namespace SchoolRegister.ViewModels.VM; 

public class TeacherVm {

    public int Id {get; set;}
    public string? FirstName {get; set;} 
    public string? LastName {get; set;}
    public string? Title {get; set;}

    public IList<SubjectVm> Subjects {get; set;}
}
