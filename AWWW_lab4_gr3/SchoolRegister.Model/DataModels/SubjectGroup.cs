using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels;

public class SubjectGroup {
    public virtual Subject? Subject {get; set;}
    [ForeignKey("SubjectId")]
    public int? SubjectId {get; set;}
    public virtual Group? Group {get; set;}
    [ForeignKey("GroupId")]
    public int? GroupId { get; set;}
    public SubjectGroup(){}
}