using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.ViewModels.VM;
public class TeacherVm
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string AcademicTitle { get; set; } = null!;
    public IList<SubjectVm> Subjects { get; set; } = null!;
}