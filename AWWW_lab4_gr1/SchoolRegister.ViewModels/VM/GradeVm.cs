using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.ViewModels.VM;
public class GradeVm
{
    public int Id { get; set; }
    [Required]
    public double Value { get; set; }
    [Required]
    public string Description { get; set; } = null!;
    public StudentVm Student { get; set; } = null!;
    public SubjectVm Subject { get; set; } = null!;
    public TeacherVm Teacher { get; set; } = null!;
    public DateTime IssueDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}