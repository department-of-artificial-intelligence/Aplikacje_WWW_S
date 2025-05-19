using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels;
public class Grade{
    [Key]
    public DateTime DateOfIssue { get; set; }
    public GradeScale GradeValue { get; set; }
    public virtual Subject? Subject {get; set;}
    [ForeignKey("SubjectId")]
    public int? SubjectId {get; set;}
    [ForeignKey("StudentId")]
    public int? StudentId {get; set;}
    public virtual Student? Student {get; set;}
    public Grade(){}

}