using Microsoft.AspNetCore.Identity; 
using System; 
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels; 
public class Grade
{
    public int Id { get; set; }
    public DateTime DateOfIssue { get; set; }
    public GradeScale GradeValue { get; set; }
    
    [ForeignKey("SubjectId")]
    public virtual Subject Subject { get; set; }
    public int SubjectId { get; set; }
    [ForeignKey("StudentId")]
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

public Grade()
    {

    }
}