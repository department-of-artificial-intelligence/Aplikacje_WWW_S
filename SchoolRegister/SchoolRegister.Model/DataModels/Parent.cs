using System;
namespace SchoolRegister.Model.DataModels;
public class Parent
{
    public IList<Student> Students { get; set; } = new List<Student>();
}