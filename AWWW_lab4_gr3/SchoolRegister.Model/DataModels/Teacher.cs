using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels;

public class Teacher : User
{
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual IList<Subject> Subjects {get; set;} 

    public Teacher()
    {
    }  
}