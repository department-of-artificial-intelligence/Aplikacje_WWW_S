using Microsoft.AspNetCore.Identity; 
using System; 
namespace SchoolRegister.Model.DataModels; 
public class Parent : User
{
    public IList<Student> Students { get; set; } = new List<Student>();

    public Parent()
    {
        Students = new List<Student>();
    }
}