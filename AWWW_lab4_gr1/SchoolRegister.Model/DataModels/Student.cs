using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Student : User
{
    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public ICollection<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
}