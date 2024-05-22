using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels;
public class Subject
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual IList<SubjectGroup> SubjectGroups { get; set; }
    public Teacher Teacher { get; set; }
    [ForeignKey("Teacher")]
    public int? TeacherId { get; set; }
    public virtual IList<Grade> Grades { get; set; }
    public Subject() { }
}
