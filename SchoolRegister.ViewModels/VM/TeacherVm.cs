using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model;
namespace SchoolRegister.ViewModels.VM;

public class AddOrUpdateTeacherVm {
    public int? Id { get;set;}
    [Required]
    public string Title {get;set;} = null!;
}

public class TeachersGroupsVm {
    public int TeacherId { get; set; }
}

public class TeacherVm
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    IList<SubjectVm> Subjects { get; set; }
}