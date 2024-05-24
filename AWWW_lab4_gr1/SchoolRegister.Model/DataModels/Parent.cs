using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Parent
{
    public ICollection<Student> Students { get; set; } = new List<Student>();
}