using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels;
public class Teacher
{
    public virtual IList<Subject> Subjects { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    public Teacher() { }
}