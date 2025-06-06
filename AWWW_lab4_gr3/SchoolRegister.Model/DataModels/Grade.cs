using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.Model.DataModels;

public class Grade
{
    public int Id { get; set; }
    public DateTime DateOfIssue { get; set; }
    public GradeScale GradeValue { get; set; }
    public virtual Subject? Subject { get; set; }

    [ForeignKey("Subject")]
    public int? SubjectId { get; set; }

    [ForeignKey("Student")]
    public int? StudentId { get; set; }
    public virtual Student? Student { get; set; }

    public Grade() { }
}
