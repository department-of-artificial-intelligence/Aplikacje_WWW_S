using Microsoft.AspNetCore.Identity; 
using System; 
namespace SchoolRegister.Model.DataModels; 
using System.ComponentModel.DataAnnotations.Schema;
public class SubjectGroup
{
    [ForeignKey("SubjectId")]
    public virtual Subject Subject { get; set; }
    public int SubjectId { get; set;}


    [ForeignKey("GroupId")]
    public virtual Group Group { get; set; }
 
    public int GroupId { get; set; }
    public SubjectGroup()
    {
    
    }

}