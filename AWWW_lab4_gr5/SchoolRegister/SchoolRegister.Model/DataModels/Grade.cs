using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;
public class Grade
{
    public DateTime DateOfIssue { get; set; } = DateTime.Now;
    public GradeScale GradeValue { get; set; }
    public Subject Subject { get; set; }
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public Grade() { }
}
