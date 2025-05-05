using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;

public class SubjectGroup
{
    [ForeignKey("Subject")]
    public int SubjectId {get; set;}
    public virtual Subject Subject {get; set;} = null!;

    [ForeignKey("Group")]
    public int GroupId {get; set;}
    public virtual Group Group {get; set;} = null!;

    SubjectGroup() {}
}