using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;
public class SubjectGroup
{
    public Subject Subject { get; set; }
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }
    public Group Group { get; set; }
    [ForeignKey("Group")]
    public int GroupId { get; set; }
    public SubjectGroup() { }
}
