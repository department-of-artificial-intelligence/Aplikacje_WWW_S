namespace SchoolRegister.ViewModels.VM;

public class TeacherVm
{
    public int Id {get; set;}
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string Title {get; set;} = null!;
    public IList<SubjectVm> Subjects {get; set;} = null!;
}