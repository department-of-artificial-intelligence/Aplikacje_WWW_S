// using Microsoft.AspNetCore.Mvc;
using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels; 
public class Subject {
    public int Id {get; set;}
    public required string Name {get; set;}
    public string? Description {get; set;}
    public virtual IList<SubjectGroup>? SubjectGroups {get; set;}
    public required virtual Teacher Teacher {get; set;}
    public int? TeacherId {get; set;}
    public virtual IList<Grade>? Grades {get; set;}
    
}