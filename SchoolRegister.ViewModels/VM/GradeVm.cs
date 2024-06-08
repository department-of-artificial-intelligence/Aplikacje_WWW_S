using System.ComponentModel.DataAnnotations;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.ViewModels.VM;

public class GradeVm
{
    public int Value { get; set; }
    public string? Description { get; set; }
    public DateTime DateOfIssue { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public virtual Student Student { get; set; }
    public virtual Subject Subject { get; set; }
    public virtual Teacher Teacher { get; set; }
}
