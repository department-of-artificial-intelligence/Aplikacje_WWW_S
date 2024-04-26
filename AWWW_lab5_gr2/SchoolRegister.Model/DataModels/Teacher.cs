using System;
namespace SchoolRegister.Model.DataModels;
public class Teacher
{
    public IList<Subject> Subjects { get; set; } = new List<Subject>();
    public string Title { get; set; } = null!;
}