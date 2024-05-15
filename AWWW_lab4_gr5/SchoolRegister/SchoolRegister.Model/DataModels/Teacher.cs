namespace SchoolRegister.Model.DataModels;
public class Teacher
{
    public virtual IList<Subject> Subjects { get; set; }
    public string Title { get; set; } = null!;
    public Teacher() { }
}