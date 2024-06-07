using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels;

public class Subject{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; } = null!;
    public virtual ICollection<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}