using System;

namespace SchoolRegister.Model.DataModels;

public class Teacher
{
    public int TeacherId { get; set; }
    public IList<Subject> Subjects { get; set; }
    public Teacher()
    {
        Subjects = new List<Subject>();
    }
}