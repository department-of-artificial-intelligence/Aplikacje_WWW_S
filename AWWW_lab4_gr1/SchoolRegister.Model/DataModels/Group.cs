using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual IList<Student> Students { get; set; }
    public virtual IList<SubjectGroup> SubjectGroups { get; set; }
}