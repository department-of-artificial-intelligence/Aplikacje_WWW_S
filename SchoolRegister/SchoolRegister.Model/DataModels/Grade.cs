using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Grade
{
    [Key]
    public required DateTime DateOfIssue { get; set; }

    public required GradeScale GradeValue { get; set; }

    public virtual Subject Subject { get; set; }

    [ForeignKey("Subject")]
    public required int SubjectId { get; set; }

    public virtual Student Student { get; set; }

    [ForeignKey("Student")]
    public required int StudentId { get; set; }

}