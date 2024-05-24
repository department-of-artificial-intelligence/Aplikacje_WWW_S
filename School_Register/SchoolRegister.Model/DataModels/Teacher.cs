// using Microsoft.AspNetCore.Mvc; 
using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels; 
public class Teacher: User {
    public virtual IList<Subject>? Subjects {get; set;}
    public required string Title {get; set;}

}