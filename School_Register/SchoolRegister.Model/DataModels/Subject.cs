using Microsoft.AspNetCore.Identity; 
using System; 
namespace SchoolRegister.Model.DataModels; 

public class Subject 
{
    public string Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}

    public IList<SubjectGroup> SubjectGroups { get; set;}
    public Teacher Teacher { get; set;}
    public TeacherId TeacherId{ get; set;}
    public IList<Grade> Grades { get; set;}
}