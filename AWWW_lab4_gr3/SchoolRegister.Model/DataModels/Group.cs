using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels;

public class Group
{
    public int Id {get; set;}
    public string Name {get; set;}
    public IList<Student> Students {get; set;} = null;
    public IList<SubjectGroup> SubjectGroups {get; set;}
    public Group(){};
}