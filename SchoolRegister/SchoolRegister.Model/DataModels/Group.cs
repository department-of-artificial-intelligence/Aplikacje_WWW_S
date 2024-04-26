using System;
namespace SchoolRegister.Model.DataModels;
public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IList<Student> Students { get; set; } = new List<Student>();
    public IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
}