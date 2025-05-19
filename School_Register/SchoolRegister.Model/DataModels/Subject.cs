using Microsoft.AspNetCore.Identity; 
using System; 
namespace SchoolRegister.Model.DataModels; 
using System.ComponentModel.DataAnnotations.Schema;
public class Subject 
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}

    
    public virtual IList<SubjectGroup> SubjectGroups { get; set;}

    [ForeignKey("TeacherId")]
    public virtual Teacher Teacher { get; set;}
 
    public int? TeacherId{ get; set;}
    public virtual IList<Grade> Grades { get; set;}

    public Subject()
    {
        SubjectGroups = new List<SubjectGroup>();
        Grades = new List<Grade>();
    }
}