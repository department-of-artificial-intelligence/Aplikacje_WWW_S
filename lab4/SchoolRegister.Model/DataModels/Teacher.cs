using SchoolRegister.Model.DataModels;

public class Teacher : User
{
    public virtual IList<Subject> Subjects { get; set; }
    public required string Title { get; set; }
}