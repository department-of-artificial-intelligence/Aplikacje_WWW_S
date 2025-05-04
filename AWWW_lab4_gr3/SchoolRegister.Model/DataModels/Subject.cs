using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels;

public class Subject
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public IList<SubjectGroup> SubjectGroup {get; set;} = null;
    public virtual Teacher Teacher { get; set;}
    public int? TeacherId {get; set;}
    public IList<Grade> Grades {get; set;} = null;
    public Subject(){};

}