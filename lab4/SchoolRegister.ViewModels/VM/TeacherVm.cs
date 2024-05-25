using SchoolRegister.ViewModels.VM;

public class TeacherVm
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public IList<SubjectVm> Subjects { get; set; } = null!;
    public IList<SubjectVm> SubjectsTaught { get; set; } = null!;
    public IList<GroupVm> Groups { get; set; } = null!;
    public IList<GradeVm> Grades { get; set; } = null!;
}