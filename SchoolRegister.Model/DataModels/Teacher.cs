
using System;

namespace SchoolRewgister.Model.DataModels;

public class Teacher
{
    public IList<Subject> Subjects{ get; set; }
    public string Title { get; set; }
}