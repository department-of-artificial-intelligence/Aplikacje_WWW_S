using Microsoft.AspNetCore.Identity; 
using System; 
namespace SchoolRegister.Model.DataModels; 

public class Teacher : User
{
    public IList <Subject> Subjects { get; set; }
    public string Title { get; set; }

    public Teacher(IList<Subject> subjects Title title)
    {
        Subjects = new List<Subject>();
        Title = title;



    }

}