using Microsoft.AspNetCore.Identity;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;

public class Grade
{
    public DateTime DateOfIssue { get; set; } 
    public GradeScale GradeValue { get; set; }
    public required virtual Subject Subject { get; set; }
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    public int StudentId { get; set; }
    public required virtual Student Student { get; set; }

}