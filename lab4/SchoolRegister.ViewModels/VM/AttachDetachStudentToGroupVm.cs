using System.ComponentModel.DataAnnotations;

public class AttachDetachStudentToGroupVm
{
    [Required]
    public int StudentId { get; set; }
    [Required]
    public int GroupId { get; set; }
}