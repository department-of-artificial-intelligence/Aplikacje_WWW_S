using System.ComponentModel.DataAnnotations;

public class AttachDetachSubjectGroupVm
{
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public int GroupId { get; set; }
}