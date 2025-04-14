
using System;
namespace SchoolRegister.Model.DataModels;
public class Teacher
{
    public IList<Subject> Subject {get; set;}
    public string Title {get; set;}
    public Teacher(IList<Subject> subject , string title){
        Subject = subject;
        Title = title;
    }
}