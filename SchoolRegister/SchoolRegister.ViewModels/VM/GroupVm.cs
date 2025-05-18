namespace SchoolRegister.ViewModels.VM;

public class GroupVm
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public IList<StudentVm> Students = null!;
    public IList<SubjectVm> Subjects = null!;
}