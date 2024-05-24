using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public required IList<Student> Students { get; set; }
    public required IList<SubjectGroup> SubjectGroups { get; set; }
}