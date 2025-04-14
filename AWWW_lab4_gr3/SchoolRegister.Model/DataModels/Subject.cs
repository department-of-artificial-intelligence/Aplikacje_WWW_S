using System;
namespace SchoolRegister.Model.DataModels;
public class Subject
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    public IList<SubjectGroup> SubjectGroups { get; set;}
    public Teacher Teacher{ get; set;}
    public int? TeacherId { get; set;}
    public IList<Grade> Grades { get; set;}

    public Subject(int id, string name, string description,IList<SubjectGroup> subjectGroups, Teacher teacher , int teacherId ,  IList<Grade> grades ){
        Id = id;
        Name = name;
        Description = description;
        SubjectGroups = subjectGroups;
        Teacher = teacher;
        TeacherId = teacherId;
        Grades = grades;
    }
}