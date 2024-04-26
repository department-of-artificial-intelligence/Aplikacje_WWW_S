// using Microsoft.AspNetCore.Mvc; 
using System; 

namespace SchoolRegister.Model.DataModels; 
public class Teacher: User {
    public IList<Subject> Subjects {get; set;}
    public required string Title {get; set;}

}