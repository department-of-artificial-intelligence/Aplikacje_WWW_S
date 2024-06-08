

namespace SchoolRegister.ViewModels.VM; 

public class TeachersGroupsVm {

    public int TeacherId {get; set;}
    public string? TeacherName {get; set;}
    public IList<GroupVm> Groups {get; set;}
}