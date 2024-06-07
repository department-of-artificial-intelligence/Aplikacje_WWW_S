using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Teacher : User
{
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public required string Title { get; set; }
}