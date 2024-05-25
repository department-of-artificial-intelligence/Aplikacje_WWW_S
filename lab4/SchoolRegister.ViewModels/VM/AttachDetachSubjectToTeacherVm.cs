using System.ComponentModel.DataAnnotations;

public class AttachDetachSubjectToTeacherVm
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public int TeacherId { get; set; }
}