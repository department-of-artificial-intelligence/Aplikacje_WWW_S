using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model;
namespace SchoolRegister.ViewModels.VM;

public class AddOrUpdateGroupVm {
    public int? Id { get;set;}
    [Required]
    public string Name {get;set;} = null!;
}

public class AttachDetachStudentToGroupVm {
    public int GroupId {get;set;}
    public int StudentId {get; set;}
}

public class AttachDetachSubjectGroupVm {
    public int GroupId {get;set;}
    public int SubjectId {get; set;}
}

public class AttachDetachSubjectToTeacherVm {
    public int SubjectId {get;set;}
    public int TeacherId {get; set;}
}

public class GroupVm
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public IList<StudentVm> Students { get; set; } = null!;
    public IList<SubjectVm> Subjects { get; set; } = null!;
}