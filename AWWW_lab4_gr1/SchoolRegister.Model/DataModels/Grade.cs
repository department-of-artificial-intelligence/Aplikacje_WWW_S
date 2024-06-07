using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SchoolRegister.Model.DataModels;

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