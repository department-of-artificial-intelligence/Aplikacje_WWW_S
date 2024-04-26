using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels { 
public class Subject
    {
    public int Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IList<SubjectGroup> { get; set;} = null!;
    public Teacher Teacher { get; set; } = null!;
    public int? TeacherId { get; set; } = null!;
    public IList<Grade> Grades { get; set; } = null!;
    }
}
